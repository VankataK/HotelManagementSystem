using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Web.ViewModels.ExtraService
{
    public class ExtraServiceIndexViewModel
    {
        public string Id { get; set; } = null!;

        public string ServiceName { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
