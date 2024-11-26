using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Data.Models
{
    public class ExtraService
    {
        [Key]
        [Comment("Service Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(250)]
        [Comment("Service name")]
        public string ServiceName { get; set; } = null!;

        [MaxLength(500)]
        [Comment("Service description")]
        public string? Description { get; set; }

        [Required]
        [Comment("Service price")]
        public decimal Price { get; set; }

        public ICollection<ReservationExtraService> ReservationsExtraServices { get; set; } = new List<ReservationExtraService>();
    }
}
