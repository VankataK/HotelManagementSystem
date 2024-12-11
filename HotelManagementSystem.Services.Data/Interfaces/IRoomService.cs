using HotelManagementSystem.Web.ViewModels.Admin.RoomManagment;
using HotelManagementSystem.Web.ViewModels.Room;

namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<AllRoomsViewModel>> GetAllRoomsAsync();
        Task<IEnumerable<RoomIndexViewModel>> IndexGetAllOrderedByRoomNumberAsync();
        Task AddRoomAsync(AddRoomInputModel inputModel);
        Task<RoomDetailsViewModel?> GetRoomDetailsByIdAsync(Guid id);
        Task<AddRoomToReservationViewModel?> GetRoomForReservationByIdAsync(Guid id);
    }
}
