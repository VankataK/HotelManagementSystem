using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Web.ViewModels.Category
{
    public class RoomSelectCategoryFormModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
