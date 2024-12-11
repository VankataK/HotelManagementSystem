using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeRoomIdCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsAvailabilities_Rooms_RoomId",
                table: "RoomsAvailabilities");

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("0034df30-ade1-4b11-b4fb-bbb2f5a823e3"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("4293aa62-7935-41d2-9462-9db7358ec3e3"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("63a30e93-70f2-4a36-b49a-276dcf3d0584"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("74139da6-7aeb-4f75-9495-3b63a24ae50b"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("efbfeb13-cdf3-4d52-a81b-0000a9f2bd2a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3e270f05-9a75-4600-9e71-d8f547c0f062"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7d5d0ad0-9f43-4a68-9fef-ff8bc8e9f596"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("89b0688d-b715-4619-8115-e345eac89c89"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b3a9869a-11ad-41fa-9cfa-f713bce59b14"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e6ba622a-7085-4dbd-8c6a-87c0f38999ce"));

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "Description", "Price", "ServiceName" },
                values: new object[,]
                {
                    { new Guid("0fc70d3b-4e9a-4f7f-9a17-1aaf5c6f21bd"), "Extend your stay until 2 PM.", 15.00m, "Late Checkout" },
                    { new Guid("2ee392c9-cf45-4962-933f-05764dbdf69c"), "Comfortable transport to and from the airport.", 50.00m, "Airport Transfer" },
                    { new Guid("4ae43935-09c7-4199-9c4d-7fed26c63eab"), "Relax with our exclusive spa treatments.", 100.00m, "Spa Package" },
                    { new Guid("979c3666-32b0-4b87-88c8-b737a62ee0b4"), "Delicious breakfast served daily.", 30.00m, "Breakfast" },
                    { new Guid("9a8e0b71-5d98-472f-bcf6-9cee20695d0c"), "Order meals and drinks to your room.", 20.00m, "Room Service" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "MaxCapacity", "PricePerNight", "RoomNumber" },
                values: new object[,]
                {
                    { new Guid("1432b5c6-f8ed-4fba-86bc-b5b52459d2cc"), 2, "Stylishly designed, this double room offers comfort and functionality for a memorable stay.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg", false, 2, 120.00m, "102" },
                    { new Guid("160808f4-0e10-4cdb-aa86-b1689bf5cd47"), 5, "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.", "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg", false, 6, 7000.00m, "501" },
                    { new Guid("3a7cd083-878b-4076-bed4-fbc6b9691632"), 1, "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.", "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy", false, 1, 70.00m, "101" },
                    { new Guid("8e467c89-a95f-4c16-9735-87989cdf1d8d"), 2, "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg", false, 2, 110.00m, "103" },
                    { new Guid("a35a96b6-d84a-44d4-8745-e3e60034cc55"), 3, "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.", "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png", false, 4, 250.00m, "104" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsAvailabilities_Rooms_RoomId",
                table: "RoomsAvailabilities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsAvailabilities_Rooms_RoomId",
                table: "RoomsAvailabilities");

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("0fc70d3b-4e9a-4f7f-9a17-1aaf5c6f21bd"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("2ee392c9-cf45-4962-933f-05764dbdf69c"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("4ae43935-09c7-4199-9c4d-7fed26c63eab"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("979c3666-32b0-4b87-88c8-b737a62ee0b4"));

            migrationBuilder.DeleteData(
                table: "ExtraServices",
                keyColumn: "Id",
                keyValue: new Guid("9a8e0b71-5d98-472f-bcf6-9cee20695d0c"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1432b5c6-f8ed-4fba-86bc-b5b52459d2cc"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("160808f4-0e10-4cdb-aa86-b1689bf5cd47"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3a7cd083-878b-4076-bed4-fbc6b9691632"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8e467c89-a95f-4c16-9735-87989cdf1d8d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a35a96b6-d84a-44d4-8745-e3e60034cc55"));

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "Description", "Price", "ServiceName" },
                values: new object[,]
                {
                    { new Guid("0034df30-ade1-4b11-b4fb-bbb2f5a823e3"), "Comfortable transport to and from the airport.", 50.00m, "Airport Transfer" },
                    { new Guid("4293aa62-7935-41d2-9462-9db7358ec3e3"), "Relax with our exclusive spa treatments.", 100.00m, "Spa Package" },
                    { new Guid("63a30e93-70f2-4a36-b49a-276dcf3d0584"), "Delicious breakfast served daily.", 30.00m, "Breakfast" },
                    { new Guid("74139da6-7aeb-4f75-9495-3b63a24ae50b"), "Extend your stay until 2 PM.", 15.00m, "Late Checkout" },
                    { new Guid("efbfeb13-cdf3-4d52-a81b-0000a9f2bd2a"), "Order meals and drinks to your room.", 20.00m, "Room Service" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "MaxCapacity", "PricePerNight", "RoomNumber" },
                values: new object[,]
                {
                    { new Guid("3e270f05-9a75-4600-9e71-d8f547c0f062"), 2, "Stylishly designed, this double room offers comfort and functionality for a memorable stay.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg", false, 2, 120.00m, "102" },
                    { new Guid("7d5d0ad0-9f43-4a68-9fef-ff8bc8e9f596"), 3, "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.", "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png", false, 4, 250.00m, "104" },
                    { new Guid("89b0688d-b715-4619-8115-e345eac89c89"), 1, "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.", "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy", false, 1, 70.00m, "101" },
                    { new Guid("b3a9869a-11ad-41fa-9cfa-f713bce59b14"), 2, "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.", "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg", false, 2, 110.00m, "103" },
                    { new Guid("e6ba622a-7085-4dbd-8c6a-87c0f38999ce"), 5, "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.", "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg", false, 6, 7000.00m, "501" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsAvailabilities_Rooms_RoomId",
                table: "RoomsAvailabilities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
