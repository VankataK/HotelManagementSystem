using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Data.Repository.Interfaces;
using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.Reservation;
using static HotelManagementSystem.Common.EntityValidationConstants.Reservation;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using HotelManagementSystem.Web.ViewModels.Room;

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

        public async Task<IEnumerable<ReservationIndexViewModel>> GetAllOrderedByCheckInAsync()
        {
            IEnumerable<ReservationIndexViewModel> reservations = await this.reservationRepository
                .GetAllAttached()
                .Where(r => r.IsDeleted == false)
                .Include(r => r.Room)
                .OrderBy(r => r.CheckInDate)
                .Select(r => new ReservationIndexViewModel()
                {
                    Id = r.Id.ToString(),
                    RoomNumber = r.Room.RoomNumber,
                    CheckInDate = r.CheckInDate.ToString(ReservationDateFormat),
                    CheckOutDate = r.CheckOutDate.ToString(ReservationDateFormat),
                    TotalPrice = r.TotalPrice
                })
                .ToListAsync();

            return reservations;
        }

        public async Task<IEnumerable<ReservationIndexViewModel>> GetAllByUserIdOrderedByCheckInAsync(string userId)
        {
            IEnumerable<ReservationIndexViewModel> reservations = await this.reservationRepository
                .GetAllAttached()
                .Where(r => r.IsDeleted == false)
                .Where(r => r.GuestId.ToString() == userId)
                .Include(r => r.Room)
                .OrderBy(r => r.CheckInDate)
                .Select(r => new ReservationIndexViewModel()
                {
                    Id = r.Id.ToString(),
                    RoomNumber = r.Room.RoomNumber,
                    CheckInDate = r.CheckInDate.ToString(ReservationDateFormat),
                    CheckOutDate = r.CheckOutDate.ToString(ReservationDateFormat),
                    TotalPrice = r.TotalPrice
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

        public async Task<EditReservationFormModel?> GetReservationForEditByIdAsync(Guid id)
        {
            Reservation? reservation = await this.reservationRepository
                .GetAllAttached()
                .Where(r => r.IsDeleted == false)
                .FirstOrDefaultAsync(r => r.Id == id);

            EditReservationFormModel? reservationModel = new EditReservationFormModel()
                {
                    Id = reservation.Id.ToString(),
                    RoomId = reservation.RoomId.ToString(),
                    CheckInDate = reservation.CheckInDate.ToString(ReservationDateFormat),
                    CheckOutDate = reservation.CheckOutDate.ToString(ReservationDateFormat),
                    TotalPrice = reservation.TotalPrice
                };

            await roomAvailabilityRepository.FreeRoomDatesAsync(reservation.RoomId, reservation.CheckInDate, reservation.CheckOutDate);
            return reservationModel;
        }

        public async Task<bool> EditReservationAsync(EditReservationFormModel model)
        {
            Guid modelGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(model.Id, ref modelGuid);
            if (!isIdValid)
            {
                return false;
            }

            Reservation reservationEntity = await this.reservationRepository.GetByIdAsync(modelGuid);

            if (reservationEntity == null)
            {
                return false;
            }

            bool isCheckInDateValid = DateTime
                .TryParseExact(model.CheckInDate, ReservationDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime newCheckInDate);
            bool isCheckOutDateValid = DateTime
                .TryParseExact(model.CheckOutDate, ReservationDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime newCheckOutDate);
            if (!isCheckInDateValid || !isCheckOutDateValid)
            {
                return false;
            }

            Guid roomGuid = Guid.Empty;
            isIdValid = this.IsGuidValid(model.RoomId, ref roomGuid);
            if (!isIdValid)
            {
                return false;
            }

            bool areDatesAvailable = await this.roomAvailabilityRepository.IsAvailableAsync(roomGuid, newCheckInDate, newCheckOutDate);

            if (!areDatesAvailable)
            {
                return false;
            }

            await roomAvailabilityRepository.BlockRoomDatesAsync(roomGuid, newCheckInDate, newCheckOutDate);

            reservationEntity.CheckInDate = newCheckInDate;
            reservationEntity.CheckOutDate = newCheckOutDate;
            reservationEntity.TotalPrice = await CalculateTotalPrice(model.RoomId, reservationEntity.CheckInDate, reservationEntity.CheckOutDate);

            return await this.reservationRepository.UpdateAsync(reservationEntity);
        }

        public async Task<DeleteReservationViewModel?> GetReservationForDeleteByIdAsync(Guid id)
        {
            DeleteReservationViewModel? reservationToDelete = await this.reservationRepository
                .GetAllAttached()
                .Include(r => r.Room)
                .Where(r => r.IsDeleted == false)
                .Select(r => new DeleteReservationViewModel
                {
                    Id = r.Id.ToString(),
                    RoomNumber = r.Room.RoomNumber,
                    CheckInDate = r.CheckInDate.ToString(ReservationDateFormat),
                    CheckOutDate = r.CheckOutDate.ToString(ReservationDateFormat)
                })
                .FirstOrDefaultAsync(r => r.Id.ToLower() == id.ToString().ToLower());

            return reservationToDelete;
        }

        public async Task<bool> SoftDeleteReservationAsync(Guid id)
        {
            Reservation? reservationToDelete = await this.reservationRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());
            if (reservationToDelete == null)
            {
                return false;
            }

            reservationToDelete.IsDeleted = true;
            return await this.reservationRepository.UpdateAsync(reservationToDelete);
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
