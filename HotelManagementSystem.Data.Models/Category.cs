using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HotelManagementSystem.Common.EntityValidationConstants.Category;

namespace HotelManagementSystem.Data.Models
{
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}