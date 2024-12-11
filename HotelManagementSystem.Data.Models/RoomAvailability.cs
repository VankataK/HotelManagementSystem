using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Data.Models
{
    public class RoomAvailability
    {
        [Key]
        [Comment("RoomAvailability Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("Room Identifier")]
        public Guid RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Room Room { get; set; } = null!;

        [Required]
        [Comment("Date of use")]
        public DateTime Date { get; set; }
    }
}
