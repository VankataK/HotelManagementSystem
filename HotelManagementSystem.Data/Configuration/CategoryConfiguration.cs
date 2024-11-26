using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(GenerateCategories());
        }

        private IEnumerable<Category> GenerateCategories()
        {
            IEnumerable<Category> categories = new List<Category>() 
            {
                new Category()
                {
                    Id = 1,
                    Name = "Single room"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Double room"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Family room"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Deluxe room"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Presidential suite"
                },
            };

            return categories;
        }
    }
}
