using HotelManagementSystem.Web.ViewModels.Reservation;

namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationIndexViewModel>> GetAllOrderedByCheckInAsync();
        Task<IEnumerable<ReservationIndexViewModel>> GetAllByUserIdOrderedByCheckInAsync(string userId);
        Task<bool> CreateReservationAsync(AddReservationFormModel model, string userId);
        Task<decimal> CalculateTotalPrice(string roomId, DateTime checkInDate, DateTime checkOutDate);
        Task<List<DateTime>> GetUnavailableDatesAsync(Guid roomId);

    }
}
