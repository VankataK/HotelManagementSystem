using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Data.Repository;
using HotelManagementSystem.Data.Repository.Interfaces;
using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.Admin.RoomManagment;
using HotelManagementSystem.Web.ViewModels.Reservation;
using HotelManagementSystem.Web.ViewModels.Room;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Services.Data
{
    public class RoomService : BaseService, IRoomService
    {
        private readonly IRepository<Room, Guid> roomRepository;

        public RoomService(IRepository<Room, Guid> roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<IEnumerable<AllRoomsViewModel>> GetAllRoomsAsync()
        {
            IEnumerable<AllRoomsViewModel> rooms = await this.roomRepository
                .GetAllAttached()
                .Where(r => r.IsDeleted == false)
                .OrderBy(r => r.RoomNumber)
                .Select(r => new AllRoomsViewModel()
                {
                    Id = r.Id.ToString(),
                    RoomNumber = r.RoomNumber,
                    CategoryName = r.Category.Name
                })
                .ToListAsync();

            return rooms;
        }

        public async Task<(IEnumerable<RoomIndexViewModel> Rooms, int TotalPages)> IndexGetAllAsync(
            string? searchQuery = null, 
            string? category = null,
            int pageNumber = 1, int pageSize = 5)
        {
            IEnumerable<RoomIndexViewModel> rooms = await this.roomRepository
                .GetAllAttached()
                .Include(r => r.Category)
                .Where(r => r.IsDeleted == false)
                .Select(r => new RoomIndexViewModel()
                {
                    Id = r.Id.ToString(),
                    RoomNumber = r.RoomNumber,
                    CategoryName = r.Category.Name,
                    ImageUrl = r.ImageUrl,
                    PricePerNight = r.PricePerNight
                })
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.ToLower().Trim();
                rooms = rooms
                    .Where(r => r.RoomNumber.ToLower().Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                category = category.ToLower().Trim();
                rooms = rooms
                    .Where(r => r.CategoryName.ToLower().Contains(category));
            }

            int totalRooms = rooms.Count();
            int totalPages = (int)Math.Ceiling(totalRooms / (double)pageSize);

            rooms = rooms
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return (rooms, totalPages);
        }

        public async Task AddRoomAsync(AddRoomInputModel inputModel)
        {
            Room room = new Room() 
            {
                RoomNumber = inputModel.RoomNumber,
                CategoryId = inputModel.CategoryId,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl,
                PricePerNight = inputModel.PricePerNight,
                MaxCapacity = inputModel.MaxCapacity
            };

            await this.roomRepository.AddAsync(room);
        }

        public async Task<RoomDetailsViewModel?> GetRoomDetailsByIdAsync(Guid id)
        {
            Room? room = await this.roomRepository
                .GetAllAttached()
                .Include(r => r.Category)
                .Where(r => r.IsDeleted == false)
                .FirstOrDefaultAsync(c => c.Id == id);

            RoomDetailsViewModel? viewModel = null;
            if (room != null)
            {
                viewModel = new RoomDetailsViewModel()
                {
                    Id = room.Id.ToString(),
                    RoomNumber = room.RoomNumber,
                    CategoryName = room.Category.Name,
                    Description = room.Description,
                    ImageUrl = room.ImageUrl,
                    PricePerNight = room.PricePerNight,
                    MaxCapacity = room.MaxCapacity
                };
            }

            return viewModel;
        }

        public async Task<EditRoomFormModel?> GetRoomForEditByIdAsync(Guid id)
        {
            EditRoomFormModel? roomModel = await this.roomRepository
                .GetAllAttached()
                .Where(r => r.IsDeleted == false)
                .Select(r => new EditRoomFormModel()
                {
                    Id = r.Id.ToString(),
                    RoomNumber = r.RoomNumber,
                    CategoryId = r.CategoryId,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    PricePerNight = r.PricePerNight,
                    MaxCapacity = r.MaxCapacity
                    
                })
                .FirstOrDefaultAsync(r => r.Id.ToLower() == id.ToString().ToLower());

            return roomModel;
        }

        public async Task<bool> EditRoomAsync(EditRoomFormModel model)
        {
            Guid modelGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(model.Id, ref modelGuid);
            if (!isIdValid)
            {
                return false;
            }

            Room roomEntity = await this.roomRepository.GetByIdAsync(modelGuid);

            if (roomEntity == null)
            {
                return false;
            }

            roomEntity.RoomNumber = model.RoomNumber;
            roomEntity.CategoryId = model.CategoryId;
            roomEntity.Description = model.Description;
            roomEntity.ImageUrl = model.ImageUrl;
            roomEntity.PricePerNight = model.PricePerNight;
            roomEntity.MaxCapacity = model.MaxCapacity;

            return await this.roomRepository.UpdateAsync(roomEntity);
        }

        public async Task<AddRoomToReservationViewModel?> GetRoomForReservationByIdAsync(Guid id)
        {
            Room? room = await this.roomRepository
                .GetAllAttached()
                .Where(r => r.IsDeleted == false)
                .FirstOrDefaultAsync(c => c.Id == id);

            AddRoomToReservationViewModel? viewModel = null;
            if (room != null)
            {
                viewModel = new AddRoomToReservationViewModel()
                {
                    Id = room.Id.ToString(),
                    RoomNumber = room.RoomNumber,
                    PricePerNight = room.PricePerNight
                };
            }

            return viewModel;
        }
    }
}
