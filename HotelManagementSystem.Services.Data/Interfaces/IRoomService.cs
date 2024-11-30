using HotelManagementSystem.Web.ViewModels.Room;

namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomIndexViewModel>> IndexGetAllOrderedByRoomNumberAsync();
    }
}
