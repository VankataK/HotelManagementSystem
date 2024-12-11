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

        public ReservationController(IReservationService reservationService, IRoomService roomService, IUserService userService)
            :base(userService)
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
        public async Task<IActionResult> Manage()
        {
            bool isReceptionist = await this.IsUserReceptionistAsync();
            if (!isReceptionist)
            {
                return this.RedirectToAction(nameof(Index));
            }

            IEnumerable<ReservationIndexViewModel> reservations =
                await this.reservationService.GetAllOrderedByCheckInAsync();

            return this.View(reservations);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            bool isReceptionist = await this.IsUserReceptionistAsync();
            if (!isReceptionist)
            {
                return this.RedirectToAction("Index","Home");
            }

            Guid reservationGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref reservationGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            EditReservationFormModel? formModel = await this.reservationService
                .GetReservationForEditByIdAsync(reservationGuid);
            if (formModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditReservationFormModel formModel)
        {
            bool isReceptionist = await this.IsUserReceptionistAsync();
            if (!isReceptionist)
            {
                return this.RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool isUpdated = await this.reservationService
                .EditReservationAsync(formModel);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the reservation! Please contact administrator");
                return this.View(formModel);
            }

            return this.RedirectToAction("Manage", new { id = formModel.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            bool isReceptionist = await this.IsUserReceptionistAsync();
            if (!isReceptionist)
            {
                return this.RedirectToAction("Index", "Home");
            }

            Guid reservationGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref reservationGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteReservationViewModel? reservationToDeleteViewModel =
                await this.reservationService.GetReservationForDeleteByIdAsync(reservationGuid);
            if (reservationToDeleteViewModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(reservationToDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteReservationViewModel reservation)
        {
            bool isReceptionist = await this.IsUserReceptionistAsync();
            if (!isReceptionist)
            {
                return this.RedirectToAction("Index", "Home");
            }

            Guid reservationGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(reservation.Id, ref reservationGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            bool isDeleted = await this.reservationService
                .SoftDeleteReservationAsync(reservationGuid);
            if (!isDeleted)
            {
                TempData["ErrorMessage"] =
                    "Unexpected error occurred while trying to delete the reservation! Please contact system administrator!";
                return this.RedirectToAction(nameof(Delete), new { id = reservation.Id });
            }

            return this.RedirectToAction(nameof(Manage));
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
