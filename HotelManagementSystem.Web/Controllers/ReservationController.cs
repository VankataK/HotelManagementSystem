using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.Infrastructure.Extensions;
using HotelManagementSystem.Web.ViewModels.Reservation;
using HotelManagementSystem.Web.ViewModels.Room;
using static HotelManagementSystem.Common.EntityValidationConstants.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    [Authorize]
    public class ReservationController : BaseController
    {
        private readonly IReservationService reservationService;
        private readonly IRoomService roomService;

        public ReservationController(IReservationService reservationService, IRoomService roomService, IReceptionistService receptionistService)
            :base(receptionistService)
        {
            this.reservationService = reservationService;
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string? userId =
                this.User.GetId();

            IEnumerable<ReservationIndexViewModel> reservations =
                await this.reservationService.GetAllByUserIdOrderedByCheckInAsync(userId!);

            return View(reservations);
        }

        [HttpGet]
        public async Task<IActionResult> Make(string? roomId)
        {
            Guid roomGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(roomId, ref roomGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction("Index", "Room");
            }

            AddRoomToReservationViewModel? room = await this.roomService.GetRoomForReservationByIdAsync(roomGuid);
            if (room == null)
            {
                return NotFound();
            }

            var unavailableDates = await this.reservationService.GetUnavailableDatesAsync(roomGuid);

            var firstAvailableDate = DateTime.Today;

            while (unavailableDates.Contains(firstAvailableDate))
            {
                firstAvailableDate = firstAvailableDate.AddDays(1);
            }


            AddReservationFormModel model = new AddReservationFormModel
            {
                Room = room,
                CheckInDate = firstAvailableDate.ToString(ReservationDateFormat),
                CheckOutDate = firstAvailableDate.AddDays(1).ToString(ReservationDateFormat)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Make(AddReservationFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            string? userId =
                this.User.GetId();

            bool result = await reservationService.CreateReservationAsync(model, userId!);
            if (result == false)
            {
                return this.View(model);
            }

            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> CalculatePrice(string roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            if (checkInDate >= checkOutDate)
            {
                return BadRequest("Check-in date must be earlier than check-out date.");
            }

            Guid roomGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(roomId, ref roomGuid);
            if (!isIdValid)
            {
                return BadRequest("Invalid Room ID.");
            }

            decimal totalPrice = await reservationService.CalculateTotalPrice(roomGuid.ToString(), checkInDate, checkOutDate);

            return Json(new { totalPrice });
        }

        [HttpGet]
        public async Task<IActionResult> GetUnavailableDates(string roomId)
        {
            Guid roomGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(roomId, ref roomGuid);
            if (!isIdValid)
            {
                return BadRequest("Invalid Room ID.");
            }

            var unavailableDates = await this.reservationService.GetUnavailableDatesAsync(roomGuid);
            return Json(unavailableDates.Select(d => d.ToString(ReservationDateFormat)));
        }
    }
}
