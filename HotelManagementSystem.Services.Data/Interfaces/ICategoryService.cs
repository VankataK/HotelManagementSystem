using HotelManagementSystem.Web.ViewModels.Category;

namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<RoomSelectCategoryFormModel>> GetAllCategoriesAsync();
    }
}
