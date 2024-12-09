using HotelManagementSystem.Web.ViewModels.Room;

namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomIndexViewModel>> IndexGetAllOrderedByRoomNumberAsync();

        Task<RoomDetailsViewModel?> GetRoomDetailsByIdAsync(Guid id);

        Task<AddRoomToReservationViewModel?> GetRoomForReservationByIdAsync(Guid id);
    }
}
