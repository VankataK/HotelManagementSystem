using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Data.Models
{
    public class Payment
    {
        [Key]
        [Comment("Payment Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("Reservation Identifier")]
        public Guid ReservationId { get; set; }

        [ForeignKey(nameof(ReservationId))]
        public Reservation Reservation { get; set; } = null!;

        [Required]
        [Comment("Date of the payment")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        [Comment("Amount of the payment")]
        public decimal AmountPaid { get; set; }
    }
}
