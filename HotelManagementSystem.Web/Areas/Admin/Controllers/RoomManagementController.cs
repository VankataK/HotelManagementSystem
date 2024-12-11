using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.Controllers;
using HotelManagementSystem.Web.ViewModels.Admin.RoomManagment;
using HotelManagementSystem.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelManagementSystem.Common.ApplicationConstants;

namespace HotelManagementSystem.Web.Areas.Admin.Controllers
{
    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class RoomManagementController : BaseController
    {
        protected readonly IRoomService roomService;
        protected readonly IReservationService reservationService;
        protected readonly ICategoryService categoryService;

        public RoomManagementController(IRoomService roomService, IReservationService reservationService, ICategoryService categoryService, IUserService userService)
            :base(userService)
        {
            this.roomService = roomService;
            this.reservationService = reservationService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllRoomsViewModel> allRooms = await this.roomService
                .GetAllRoomsAsync();

            return this.View(allRooms);
        }

        [HttpGet]
#pragma warning disable CS1998
        public async Task<IActionResult> Create()
#pragma warning restore CS1998
        {
            AddRoomInputModel model = new AddRoomInputModel() 
            {
                Categories = await this.categoryService.GetAllCategoriesAsync()
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRoomInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.roomService.AddRoomAsync(inputModel);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            Guid roomGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref roomGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            EditRoomFormModel? formModel = await this.roomService
                .GetRoomForEditByIdAsync(roomGuid);

            if (formModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            formModel.Categories = await this.categoryService.GetAllCategoriesAsync();

            return this.View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoomFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool isUpdated = await this.roomService
                .EditRoomAsync(formModel);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the room! Please contact administrator");
                return this.View(formModel);
            }

            await this.reservationService.UpdateTotalPricesAsync(formModel.Id);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
