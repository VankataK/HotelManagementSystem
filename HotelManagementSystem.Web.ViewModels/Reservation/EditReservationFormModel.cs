using HotelManagementSystem.Web.ViewModels.Room;
using System.ComponentModel.DataAnnotations;
using static HotelManagementSystem.Common.EntityValidationConstants.Reservation;

namespace HotelManagementSystem.Web.ViewModels.Reservation
{
    public class EditReservationFormModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        public string RoomId { get; set; } = null!;

        [Required]
        public string CheckInDate { get; set; } = null!;

        [Required]
        public string CheckOutDate { get; set; } = null!;


        [Required]
        [Range(typeof(decimal), TotalPriceMinValue, TotalPriceMaxValue)]
        public decimal TotalPrice { get; set; }
    }
}
