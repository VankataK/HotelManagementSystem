using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HotelManagementSystem.Common.EntityValidationConstants.User;


namespace HotelManagementSystem.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("User's first name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("User's last name")]
        public string LastName { get; set; } = null!;

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
