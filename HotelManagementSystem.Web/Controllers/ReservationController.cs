using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.Infrastructure.Extensions;
using HotelManagementSystem.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    [Authorize]
    public class ReservationController : BaseController
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
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
    }
}
