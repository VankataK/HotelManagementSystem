using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Data.Models
{
    public class ReservationExtraService
    {
        [Key]
        [Comment("Reservation service Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Reservation Identifier")]
        public Guid ReservationId { get; set; }

        [ForeignKey(nameof(ReservationId))]
        public Reservation Reservation { get; set; } = null!;

        [Required]
        [Comment("Service Identifier")]
        public Guid ExtraServiceId { get; set; }

        [ForeignKey(nameof(ExtraServiceId))]
        public ExtraService ExtraService { get; set; } = null!;

        [Required]
        [Comment("Amount of service")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Total price for the service")]
        public decimal TotalPrice { get; set; }
    }
}