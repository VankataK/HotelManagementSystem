using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelManagementSystem.Common.EntityValidationConstants.Room;

namespace HotelManagementSystem.Data.Models
{
    public class Room
    {
        [Key]
        [Comment("Room Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(RoomNumberMaxLength)]
        [Comment("Room number")]
        public string RoomNumber { get; set; } = null!;

        [Required]
        [Comment("Category Identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Room description")]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("Room image url")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Nightly price")]
        public decimal PricePerNight { get; set; }

        [Required]
        [Comment("Capacity of the room")]
        public int MaxCapacity { get; set; }
    }
}
