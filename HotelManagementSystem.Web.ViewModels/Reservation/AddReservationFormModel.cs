using HotelManagementSystem.Web.ViewModels.Room;
using System.ComponentModel.DataAnnotations;
using static HotelManagementSystem.Common.EntityValidationConstants.Reservation;
using static HotelManagementSystem.Common.EntityValidationMessages.Reservation;

namespace HotelManagementSystem.Web.ViewModels.Reservation
{
    public class AddReservationFormModel
    {
        public AddRoomToReservationViewModel Room { get; set; } = null!;

        [Required(ErrorMessage = CheckInDateRequiredMessage)]
        public string CheckInDate { get; set; } = null!;

        [Required(ErrorMessage = CheckOutDateRequiredMessage)]
        public string CheckOutDate { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), TotalPriceMinValue, TotalPriceMaxValue)]
        public decimal TotalPrice { get; set; }
    }
}
