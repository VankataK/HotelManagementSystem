using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    public class RoomController : Controller
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
    }
}
