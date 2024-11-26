using HotelManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Data.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(GenerateRooms());
        }

        private IEnumerable<Room> GenerateRooms()
        {
            IEnumerable<Room> rooms = new List<Room>()
            {
                new Room()
                {
                    RoomNumber = "101",
                    CategoryId = 1,
                    Description = "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.",
                    ImageUrl = "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy",
                    PricePerNight = 70.00m,
                    MaxCapacity = 1
                },
                new Room()
                {
                    RoomNumber = "102",
                    CategoryId = 2,
                    Description = "Stylishly designed, this double room offers comfort and functionality for a memorable stay.",
                    ImageUrl = "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg",
                    PricePerNight = 120.00m,
                    MaxCapacity = 2
                },
                new Room()
                {
                    RoomNumber = "103",
                    CategoryId = 2,
                    Description = "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.",
                    ImageUrl = "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg",
                    PricePerNight = 110.00m,
                    MaxCapacity = 2
                },
                new Room()
                {
                    RoomNumber = "104",
                    CategoryId = 3,
                    Description = "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.",
                    ImageUrl = "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png",
                    PricePerNight = 250.00m,
                    MaxCapacity = 4
                },
                new Room()
                {
                    RoomNumber = "501",
                    CategoryId = 5,
                    Description = "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.",
                    ImageUrl = "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg",
                    PricePerNight = 7000.00m,
                    MaxCapacity = 6
                },
            };

            return rooms;
        }
    }
}
