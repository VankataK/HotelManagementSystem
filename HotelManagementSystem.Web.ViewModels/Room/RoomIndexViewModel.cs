
namespace HotelManagementSystem.Web.ViewModels.Room
{
    public class RoomIndexViewModel
    {
        public string Id { get; set; } = null!;

        public string RoomNumber { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal PricePerNight { get; set; }
    }
}
