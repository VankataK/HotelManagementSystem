using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Data.Models
{
    public class Reservation
    {
        [Key]
        [Comment("Reservation Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("Room Identifier")]
        public Guid RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Room Room { get; set; } = null!;

        [Required]
        [Comment("User id of the guest")]
        public Guid GuestId { get; set; }

        [ForeignKey(nameof(GuestId))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public ApplicationUser Guest { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [Comment("Check in date")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Comment("Check out date")]
        public DateTime CheckOutDate { get; set; }

        [DataType(DataType.Date)]
        [Comment("Date of reservation")]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required]
        [Comment("Reservation price")]
        public decimal TotalPrice { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public ICollection<ReservationExtraService> ReservationsExtraServices { get; set; } = new List<ReservationExtraService>();
    }
}
