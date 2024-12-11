using HotelManagementSystem.Web.ViewModels.Reservation;
using HotelManagementSystem.Web.ViewModels.Room;

namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationIndexViewModel>> GetAllOrderedByCheckInAsync();
        Task<IEnumerable<ReservationIndexViewModel>> GetAllByUserIdOrderedByCheckInAsync(string userId);
        Task<bool> CreateReservationAsync(AddReservationFormModel model, string userId);
        Task<EditReservationFormModel?> GetReservationForEditByIdAsync(Guid id);
        Task<bool> EditReservationAsync(EditReservationFormModel model);
        Task<DeleteReservationViewModel?> GetReservationForDeleteByIdAsync(Guid id);
        Task<bool> SoftDeleteReservationAsync(Guid id);
        Task<decimal> CalculateTotalPriceAsync(string roomId, DateTime checkInDate, DateTime checkOutDate);
        Task<bool> UpdateTotalPricesAsync(string roomId);
        Task<List<DateTime>> GetUnavailableDatesAsync(Guid roomId);

    }
}
