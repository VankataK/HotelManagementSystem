using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.ExtraService;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    public class ExtraServiceController : BaseController
    {
        private readonly IExtraServiceService extraServiceService;

        public ExtraServiceController(IExtraServiceService extraServiceService, IUserService userService)
            : base(userService)
        {
            this.extraServiceService = extraServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ExtraServiceIndexViewModel> extraServices =
                await this.extraServiceService.GetAllAsync();

            return View(extraServices);
        }

        [HttpGet]
        public async Task<IActionResult> AddToReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToReservation(AddToReservationFormModel formModel)
        {
            return View();
        }
    }
}
