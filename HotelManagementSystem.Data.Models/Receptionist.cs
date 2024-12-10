using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelManagementSystem.Common.EntityValidationConstants.Receptionist;

namespace HotelManagementSystem.Data.Models
{
    public class Receptionist
    {
        [Key]
        [Comment("Receptionist Identifier")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Receptionist work phone number")]
        public string WorkPhoneNumber { get; set; } = null!;

        [Required]
        [Comment("User id of the receptionist")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
