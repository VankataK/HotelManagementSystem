using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<RoomIndexViewModel> rooms = 
                await this.roomService.IndexGetAllOrderedByRoomNumberAsync();

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
