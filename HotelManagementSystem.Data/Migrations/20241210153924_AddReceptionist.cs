using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReceptionist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Receptionist Identifier"),
                    WorkPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Receptionist work phone number"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User id of the receptionist")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptionists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "Description", "Price", "ServiceName" },
                values: new object[,]
                {
                    { new Guid("ab99f751-a472-4b85-991e-22aec5e0bf68"), "Extend your stay until 2 PM.", 15.00m, "Late Checkout" },
                    { new Guid("bc948208-dca0-42a1-9efb-467dddd9f79f"), "Relax with our exclusive spa treatments.", 100.00m, "Spa Package" },
                    { new Guid("d674c587-ce6c-404d-ae3f-8569a55aba98"), "Delicious breakfast served daily.", 30.00m, "Breakfast" },
                    { new Guid("e59b1595-81aa-4d28-9e2c-3aa1b779896e"), "Order meals and drinks to your room.", 20.00m, "Room Service" },
                    { new Guid("f969ebdc-85f9-48ba-9905-6b35a871e9d4"), "Comfortable transport to and from the airport.", 50.00m, "Airport Transfer" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "MaxCapacity", "PricePerNight", "RoomNumber" },
                values: new object[,]
                {
                    { new Guid("4920eb5f-0df2-4da4-8007-5dfd6947a6df"), 2, "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg", false, 2, 110.00m, "103" },
                    { new Guid("7a09b20f-c1a7-44d8-97ca-70f71f27f3d6"), 1, "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.", "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy", false, 1, 70.00m, "101" },
                    { new Guid("97347f36-512e-450e-bbd6-668f5e8f14b4"), 2, "Stylishly designed, this double room offers comfort and functionality for a memorable stay.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg", false, 2, 120.00m, "102" },
                    { new Guid("b47e8930-7ff2-433e-a9ed-b8614bc88000"), 3, "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.", "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png", false, 4, 250.00m, "104" },
                    { new Guid("be60d08e-2ccc-42b2-88bc-b79a50afdfa0"), 5, "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.", "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg", false, 6, 7000.00m, "501" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_UserId",
                table: "Receptionists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("ab99f751-a472-4b85-991e-22aec5e0bf68"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("bc948208-dca0-42a1-9efb-467dddd9f79f"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("d674c587-ce6c-404d-ae3f-8569a55aba98"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("e59b1595-81aa-4d28-9e2c-3aa1b779896e"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("f969ebdc-85f9-48ba-9905-6b35a871e9d4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4920eb5f-0df2-4da4-8007-5dfd6947a6df"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7a09b20f-c1a7-44d8-97ca-70f71f27f3d6"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("97347f36-512e-450e-bbd6-668f5e8f14b4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b47e8930-7ff2-433e-a9ed-b8614bc88000"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("be60d08e-2ccc-42b2-88bc-b79a50afdfa0"));

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
    }
}
