using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace HotelManagementSystem.Data.Models
{
    [PrimaryKey(nameof(ReservationId),nameof(ExtraServiceId))]
    public class ReservationExtraService
    {
        [Required]
        [Comment("Reservation Identifier")]
        public Guid ReservationId { get; set; }

        [ForeignKey(nameof(ReservationId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Reservation Reservation { get; set; } = null!;

        [Required]
        [Comment("Service Identifier")]
        public Guid ExtraServiceId { get; set; }

        [ForeignKey(nameof(ExtraServiceId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public ExtraService ExtraService { get; set; } = null!;

        [Required]
        [Comment("Amount of service")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Total price for the service")]
        public decimal TotalPrice { get; set; }
    }
}