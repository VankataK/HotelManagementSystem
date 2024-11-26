using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Data.Configuration
{
    public class ExtraServiceConfiguration : IEntityTypeConfiguration<ExtraService>
    {
        public void Configure(EntityTypeBuilder<ExtraService> builder)
        {
            builder.HasData(GenerateExtraServices());
        }

        private IEnumerable<ExtraService> GenerateExtraServices()
        {
            IEnumerable<ExtraService> extraServices = new List<ExtraService>()
            {
                new ExtraService()
                {
                    ServiceName = "Breakfast",
                    Description = "Delicious breakfast served daily.",
                    Price = 30.00m
                },
                new ExtraService()
                {
                    ServiceName = "Airport Transfer",
                    Description = "Comfortable transport to and from the airport.",
                    Price = 50.00m
                },
                new ExtraService()
                {
                    ServiceName = "Spa Package",
                    Description = "Relax with our exclusive spa treatments.",
                    Price = 100.00m
                },
                new ExtraService()
                {
                    ServiceName = "Room Service",
                    Description = "Order meals and drinks to your room.",
                    Price = 20.00m
                },
                new ExtraService()
                {
                    ServiceName = "Late Checkout",
                    Description = "Extend your stay until 2 PM.",
                    Price = 15.00m
                }
            };

            return extraServices;
        }
    }
}
