namespace HotelManagementSystem.Web.ViewModels.Reservation
{
    public class ReservationIndexViewModel
    {
        public string Id { get; set; } = null!;

        public string RoomNumber { get; set; } = null!;

        public string CheckInDate { get; set; } = null!;

        public string CheckOutDate { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = null!;
    }
}
