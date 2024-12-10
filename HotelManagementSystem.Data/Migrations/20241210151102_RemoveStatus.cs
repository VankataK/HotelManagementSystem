using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("29653f67-4195-492d-a840-cf7aa77e2e0d"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("63afd870-9b85-49d4-a4ba-ca5f19e96ab2"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("8dd0b791-7d7e-46a7-b209-eea7012fff3b"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("91692577-ad01-4818-a00e-6c7d7fea6ed8"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("e731c753-fd39-4c35-8ac3-7aa43580087a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7241cda9-395d-463e-9b13-2a419d39119b"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("964e4d2f-0ec3-4bb8-971f-df14724025c6"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c97a3546-fd46-43b2-8074-14648e60ee46"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ee1f441f-69cc-4002-9144-921e1aeaca2d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ee257c54-26ef-4257-ae3c-269042cea433"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "Description", "Price", "ServiceName" },
                values: new object[,]
                {
                    { new Guid("398d06db-2f26-47b2-aae7-c9d8fa2b24f7"), "Extend your stay until 2 PM.", 15.00m, "Late Checkout" },
                    { new Guid("9ce37192-fe27-4063-b906-befb5156ef14"), "Relax with our exclusive spa treatments.", 100.00m, "Spa Package" },
                    { new Guid("b6a876f5-62ac-4768-be90-25bd3eb0e206"), "Comfortable transport to and from the airport.", 50.00m, "Airport Transfer" },
                    { new Guid("e69e0bfb-2bc1-4ab3-a953-b3ea17da3320"), "Delicious breakfast served daily.", 30.00m, "Breakfast" },
                    { new Guid("f1fcc36d-6ba8-4f3b-8e1c-3ddfeb230ac0"), "Order meals and drinks to your room.", 20.00m, "Room Service" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "MaxCapacity", "PricePerNight", "RoomNumber" },
                values: new object[,]
                {
                    { new Guid("20df2a82-6377-4441-b356-34fe3a89c732"), 2, "Stylishly designed, this double room offers comfort and functionality for a memorable stay.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg", 2, 120.00m, "102" },
                    { new Guid("2fb5aa5e-5411-4eb9-b6f5-b08cecb6599a"), 1, "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.", "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy", 1, 70.00m, "101" },
                    { new Guid("3558dc9a-a0c5-43a2-910c-2eb3618e543b"), 2, "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg", 2, 110.00m, "103" },
                    { new Guid("c2b46508-1577-4fef-a5a2-8b34d11ff002"), 3, "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.", "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png", 4, 250.00m, "104" },
                    { new Guid("eaec7ee7-c9d5-46b6-8704-f3ba6e023bc6"), 5, "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.", "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg", 6, 7000.00m, "501" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("398d06db-2f26-47b2-aae7-c9d8fa2b24f7"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("9ce37192-fe27-4063-b906-befb5156ef14"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("b6a876f5-62ac-4768-be90-25bd3eb0e206"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("e69e0bfb-2bc1-4ab3-a953-b3ea17da3320"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("f1fcc36d-6ba8-4f3b-8e1c-3ddfeb230ac0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("20df2a82-6377-4441-b356-34fe3a89c732"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("2fb5aa5e-5411-4eb9-b6f5-b08cecb6599a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3558dc9a-a0c5-43a2-910c-2eb3618e543b"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c2b46508-1577-4fef-a5a2-8b34d11ff002"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("eaec7ee7-c9d5-46b6-8704-f3ba6e023bc6"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Reservation status");

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "Description", "Price", "ServiceName" },
                values: new object[,]
                {
                    { new Guid("29653f67-4195-492d-a840-cf7aa77e2e0d"), "Delicious breakfast served daily.", 30.00m, "Breakfast" },
                    { new Guid("63afd870-9b85-49d4-a4ba-ca5f19e96ab2"), "Extend your stay until 2 PM.", 15.00m, "Late Checkout" },
                    { new Guid("8dd0b791-7d7e-46a7-b209-eea7012fff3b"), "Relax with our exclusive spa treatments.", 100.00m, "Spa Package" },
                    { new Guid("91692577-ad01-4818-a00e-6c7d7fea6ed8"), "Order meals and drinks to your room.", 20.00m, "Room Service" },
                    { new Guid("e731c753-fd39-4c35-8ac3-7aa43580087a"), "Comfortable transport to and from the airport.", 50.00m, "Airport Transfer" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "MaxCapacity", "PricePerNight", "RoomNumber" },
                values: new object[,]
                {
                    { new Guid("7241cda9-395d-463e-9b13-2a419d39119b"), 2, "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg", 2, 110.00m, "103" },
                    { new Guid("964e4d2f-0ec3-4bb8-971f-df14724025c6"), 5, "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.", "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg", 6, 7000.00m, "501" },
                    { new Guid("c97a3546-fd46-43b2-8074-14648e60ee46"), 3, "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.", "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png", 4, 250.00m, "104" },
                    { new Guid("ee1f441f-69cc-4002-9144-921e1aeaca2d"), 2, "Stylishly designed, this double room offers comfort and functionality for a memorable stay.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg", 2, 120.00m, "102" },
                    { new Guid("ee257c54-26ef-4257-ae3c-269042cea433"), 1, "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.", "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy", 1, 70.00m, "101" }
                });
        }
    }
}
