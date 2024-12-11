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
        Task<EditRoomFormModel?> GetRoomForEditByIdAsync(Guid id);
        Task<bool> EditRoomAsync(EditRoomFormModel model);
        Task<AddRoomToReservationViewModel?> GetRoomForReservationByIdAsync(Guid id);
    }
}
