namespace HotelManagementSystem.Web.ViewModels.Reservation
{
    public class DeleteReservationViewModel
    {
        public string Id { get; set; } = null!;

        public string RoomNumber { get; set; } = null!;

        public string CheckInDate { get; set; } = null!;

        public string CheckOutDate { get; set; } = null!;
    }
}
