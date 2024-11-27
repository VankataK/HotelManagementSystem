using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("4bc19092-3d5e-4220-ad77-eaa13d82022f"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("668ad4a6-bee3-410e-b9d5-b26642be0181"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("8cd4e36b-7508-450a-a5ff-4c310e0eb443"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("8d579ffc-84cc-4c21-8d75-227f22be5426"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("cc9f2d7d-7297-4ac4-adf0-4bffc75983e2"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("112929a0-f4d8-4047-bc88-5dd2dee6ec58"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1fc6b274-e4e8-41be-bbf8-ba50fdf16b5c"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6393bd47-214f-4517-ad50-9d266c887a7d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7cef7c8c-1773-432b-9e1b-38c7f2094574"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("85b142bd-bfae-4637-90b9-869c021ab2f8"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Payment Identifier"),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Reservation Identifier"),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the payment"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the payment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "Description", "Price", "ServiceName" },
                values: new object[,]
                {
                    { new Guid("4bc19092-3d5e-4220-ad77-eaa13d82022f"), "Delicious breakfast served daily.", 30.00m, "Breakfast" },
                    { new Guid("668ad4a6-bee3-410e-b9d5-b26642be0181"), "Order meals and drinks to your room.", 20.00m, "Room Service" },
                    { new Guid("8cd4e36b-7508-450a-a5ff-4c310e0eb443"), "Comfortable transport to and from the airport.", 50.00m, "Airport Transfer" },
                    { new Guid("8d579ffc-84cc-4c21-8d75-227f22be5426"), "Extend your stay until 2 PM.", 15.00m, "Late Checkout" },
                    { new Guid("cc9f2d7d-7297-4ac4-adf0-4bffc75983e2"), "Relax with our exclusive spa treatments.", 100.00m, "Spa Package" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "MaxCapacity", "PricePerNight", "RoomNumber" },
                values: new object[,]
                {
                    { new Guid("112929a0-f4d8-4047-bc88-5dd2dee6ec58"), 1, "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.", "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy", 1, 70.00m, "101" },
                    { new Guid("1fc6b274-e4e8-41be-bbf8-ba50fdf16b5c"), 2, "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg", 2, 110.00m, "103" },
                    { new Guid("6393bd47-214f-4517-ad50-9d266c887a7d"), 2, "Stylishly designed, this double room offers comfort and functionality for a memorable stay.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg", 2, 120.00m, "102" },
                    { new Guid("7cef7c8c-1773-432b-9e1b-38c7f2094574"), 3, "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.", "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png", 4, 250.00m, "104" },
                    { new Guid("85b142bd-bfae-4637-90b9-869c021ab2f8"), 5, "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.", "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg", 6, 7000.00m, "501" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReservationId",
                table: "Payments",
                column: "ReservationId");
        }
    }
}
