using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Data.Repository.Interfaces;
using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.Reservation;
using HotelManagementSystem.Web.ViewModels.Room;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Services.Data
{
    public class ReservationService : BaseService, IReservationService
    {
        private readonly IRepository<Reservation, Guid> reservationRepository;

        public ReservationService(IRepository<Reservation, Guid> reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<ReservationIndexViewModel>> GetAllByUserIdOrderedByCheckInAsync(string userId)
        {
            IEnumerable<ReservationIndexViewModel> reservations = await this.reservationRepository
                .GetAllAttached()
                .Where(r => r.GuestId.ToString() == userId)
                .Include(r => r.Room)
                .OrderBy(r => r.CheckInDate)
                .Select(r => new ReservationIndexViewModel()
                {
                    Id = r.Id.ToString(),
                    RoomNumber = r.Room.RoomNumber,
                    CheckInDate = r.CheckInDate.ToString("dd MMMM yyyy"),
                    CheckOutDate = r.CheckOutDate.ToString("dd MMMM yyyy"),
                    TotalPrice = r.TotalPrice,
                    Status = r.Status,
                })
                .ToListAsync();

            return reservations;
        }
    }
}
