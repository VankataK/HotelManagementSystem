using System.ComponentModel.DataAnnotations;
using HotelManagementSystem.Web.ViewModels.Category;
using static HotelManagementSystem.Common.EntityValidationConstants.Room;
using static HotelManagementSystem.Common.EntityValidationMessages.Room;

namespace HotelManagementSystem.Web.ViewModels.Admin.RoomManagment
{
    public class EditRoomFormModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = RoomNumberRequiredMessage)]
        [StringLength(RoomNumberMaxLength, MinimumLength = RoomNumberMinLength)]
        public string RoomNumber { get; set; } = null!;

        public int CategoryId { get; set; }

        public IEnumerable<RoomSelectCategoryFormModel> Categories { get; set; } = new List<RoomSelectCategoryFormModel>();

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ImageUrlRequiredMessage)]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = PricePerNightRequiredMessage)]
        [Range(typeof(decimal), PricePerNightMinValue, PricePerNightMaxValue)]
        public decimal PricePerNight { get; set; }

        [Required(ErrorMessage = MaxCapacityRequiredMessage)]
        [Range(MaxCapacityMinValue, MaxCapacityMaxValue)]
        public int MaxCapacity { get; set; }
    }
}
