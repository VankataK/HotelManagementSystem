using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService, IUserService userService)
            :base(userService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            string? searchQuery = null, 
            string? category = null,
            int pageNumber = 1, int pageSize = 5)
        {
            (IEnumerable<RoomIndexViewModel> rooms, int totalPages) = 
                await this.roomService.IndexGetAllAsync(searchQuery, category, pageNumber, pageSize);

            ViewData["SearchQuery"] = searchQuery;
            ViewData["Category"] = category;
            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = totalPages;

            return View(rooms);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid roomGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref roomGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            RoomDetailsViewModel? viewModel = await this.roomService
                .GetRoomDetailsByIdAsync(roomGuid);

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(viewModel);
        }
    }
}
