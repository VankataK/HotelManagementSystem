using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Data.Repository.Interfaces;
using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Services.Data
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IRepository<Category, Guid> categoryRepository;

        public CategoryService(IRepository<Category, Guid> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<RoomSelectCategoryFormModel>> GetAllCategoriesAsync()
        {
            IEnumerable<RoomSelectCategoryFormModel> categories = await categoryRepository
                .GetAllAttached()
                .Select(c => new RoomSelectCategoryFormModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return categories;
        }
    }
}
