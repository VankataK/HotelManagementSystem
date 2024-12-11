using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.Admin.RoomManagment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelManagementSystem.Common.ApplicationConstants;

namespace HotelManagementSystem.Web.Areas.Admin.Controllers
{
    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class RoomManagementController : Controller
    {
        protected readonly IRoomService roomService;
        protected readonly ICategoryService categoryService;

        public RoomManagementController(IRoomService roomService, ICategoryService categoryService) 
        {
            this.roomService = roomService;
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
    }
}
