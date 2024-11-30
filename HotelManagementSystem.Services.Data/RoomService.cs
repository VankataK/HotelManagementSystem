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
    }
}
