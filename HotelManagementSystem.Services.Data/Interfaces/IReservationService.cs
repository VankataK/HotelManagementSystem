using HotelManagementSystem.Web.ViewModels.Reservation;

namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationIndexViewModel>> GetAllByUserIdOrderedByCheckInAsync(string userId);

    }
}
