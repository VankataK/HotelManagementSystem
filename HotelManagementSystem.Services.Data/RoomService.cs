using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Data.Repository.Interfaces;
using HotelManagementSystem.Services.Data.Interfaces;
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

        public async Task<IEnumerable<RoomIndexViewModel>> IndexGetAllOrderedByRoomNumberAsync()
        {
            IEnumerable<RoomIndexViewModel> rooms = await this.roomRepository
                .GetAllAttached()
                .OrderBy(r => r.RoomNumber)
                .Select(r => new RoomIndexViewModel()
                {
                    Id = r.Id.ToString(),
                    RoomNumber = r.RoomNumber,
                    CategoryName = r.Category.Name,
                    ImageUrl = r.ImageUrl,
                    PricePerNight = r.PricePerNight
                })
                .ToListAsync();

            return rooms;
        }

        public async Task<RoomDetailsViewModel?> GetRoomDetailsByIdAsync(Guid id)
        {
            Room? room = await this.roomRepository
                .GetAllAttached()
                .Include(r => r.Category)
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

    }
}
