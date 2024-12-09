using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Data.Repository.Interfaces;
using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.Reservation;
using static HotelManagementSystem.Common.EntityValidationConstants.Reservation;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HotelManagementSystem.Services.Data
{
    public class ReservationService : BaseService, IReservationService
    {
        private readonly IRepository<Reservation, Guid> reservationRepository;
        private readonly IRepository<Room, Guid> roomRepository;
        private readonly IRoomAvailabilityRepository roomAvailabilityRepository;

        public ReservationService(IRepository<Reservation, Guid> reservationRepository, IRepository<Room, Guid> roomRepository, IRoomAvailabilityRepository roomAvailabilityRepository)
        {
            this.reservationRepository = reservationRepository;
            this.roomRepository = roomRepository;
            this.roomAvailabilityRepository = roomAvailabilityRepository;
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

        public async Task<bool> CreateReservationAsync(AddReservationFormModel model, string userId)
        {
            Guid roomGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(model.Room.Id, ref roomGuid);
            if (!isIdValid)
            {
                return false;
            }
            bool isCheckInDateValid = DateTime
                .TryParseExact(model.CheckInDate, ReservationDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime checkInDate);
            bool isCheckOutDateValid = DateTime
                .TryParseExact(model.CheckOutDate, ReservationDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime checkOutDate);
            if (!isCheckInDateValid || !isCheckOutDateValid)
            {
                return false;
            }

            bool isAvailable = await this.roomAvailabilityRepository.IsAvailableAsync(roomGuid, checkInDate, checkOutDate);
            if (!isAvailable)
            {
                return false;
            }

            await this.roomAvailabilityRepository.BlockRoomDatesAsync(roomGuid, checkInDate, checkOutDate);

            Reservation reservation = new Reservation() 
            {
                RoomId = Guid.Parse(model.Room.Id),
                GuestId = Guid.Parse(userId),
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                TotalPrice = await this.CalculateTotalPrice(model.Room.Id, checkInDate, checkOutDate)
            };

            await this.reservationRepository.AddAsync(reservation);

            return true;
        }

        public async Task<decimal> CalculateTotalPrice(string roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            var room = await roomRepository.GetByIdAsync(Guid.Parse(roomId));
            if (room == null) throw new ArgumentException("Room not found.");

            int nights = (int)(checkOutDate - checkInDate).TotalDays;
            return room.PricePerNight * nights;
        }

        public async Task<List<DateTime>> GetUnavailableDatesAsync(Guid roomId)
        {
            return await this.roomAvailabilityRepository.GetUnavailableDatesAsync(roomId);
        }
    }
}
