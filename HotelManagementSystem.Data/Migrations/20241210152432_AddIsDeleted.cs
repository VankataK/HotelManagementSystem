using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "Description", "Price", "ServiceName" },
                values: new object[,]
                {
                    { new Guid("30495f92-67f6-450e-8ebb-5fd3b7bdc430"), "Order meals and drinks to your room.", 20.00m, "Room Service" },
                    { new Guid("6e8a6415-bd55-4e34-93f7-70b7b2222e05"), "Extend your stay until 2 PM.", 15.00m, "Late Checkout" },
                    { new Guid("8f8a8956-9b8d-4403-ba6e-1c6b68891094"), "Comfortable transport to and from the airport.", 50.00m, "Airport Transfer" },
                    { new Guid("c0cb0efc-1662-40ea-9670-cb8da69bbb44"), "Relax with our exclusive spa treatments.", 100.00m, "Spa Package" },
                    { new Guid("d97ddb96-3d83-4bc0-b1bb-20f6f2e09e4d"), "Delicious breakfast served daily.", 30.00m, "Breakfast" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "MaxCapacity", "PricePerNight", "RoomNumber" },
                values: new object[,]
                {
                    { new Guid("70ae75e3-7688-4b02-bc92-bf57015a02be"), 2, "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg", false, 2, 110.00m, "103" },
                    { new Guid("76083e22-47e7-42de-b743-a36a6b8b9675"), 2, "Stylishly designed, this double room offers comfort and functionality for a memorable stay.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg", false, 2, 120.00m, "102" },
                    { new Guid("d4394af8-d4f5-4d90-b0b5-f5b903f0bc5b"), 3, "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.", "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png", false, 4, 250.00m, "104" },
                    { new Guid("ef936fa6-2f67-49d0-b56c-aeabfedf52e2"), 1, "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.", "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy", false, 1, 70.00m, "101" },
                    { new Guid("fa18e1f8-f57a-4437-b473-ca8c8a308f22"), 5, "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.", "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg", false, 6, 7000.00m, "501" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("30495f92-67f6-450e-8ebb-5fd3b7bdc430"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("6e8a6415-bd55-4e34-93f7-70b7b2222e05"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("8f8a8956-9b8d-4403-ba6e-1c6b68891094"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("c0cb0efc-1662-40ea-9670-cb8da69bbb44"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("d97ddb96-3d83-4bc0-b1bb-20f6f2e09e4d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("70ae75e3-7688-4b02-bc92-bf57015a02be"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("76083e22-47e7-42de-b743-a36a6b8b9675"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d4394af8-d4f5-4d90-b0b5-f5b903f0bc5b"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ef936fa6-2f67-49d0-b56c-aeabfedf52e2"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fa18e1f8-f57a-4437-b473-ca8c8a308f22"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
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
    }
}
