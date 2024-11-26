using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "User's first name"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "User's last name"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Service Identifier"),
                    ServiceName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Service name"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Service description"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Service price")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Room Identifier"),
                    RoomNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Room number"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Room description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false, comment: "Room image url"),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Nightly price"),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false, comment: "Capacity of the room")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Reservation Identifier"),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Room Identifier"),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User id of the guest"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check in date"),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check out date"),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of reservation"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Reservation price"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Reservation status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_GuestId",
                        column: x => x.GuestId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomsAvailabilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "RoomAvailability Identifier"),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Room Identifier"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of use")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomsAvailabilities_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Payment Identifier"),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Reservation Identifier"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the payment"),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the payment")
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

            migrationBuilder.CreateTable(
                name: "ReservationsExtraServices",
                columns: table => new
                {
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Reservation Identifier"),
                    ExtraServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Service Identifier"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Amount of service"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total price for the service")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsExtraServices", x => new { x.ReservationId, x.ExtraServiceId });
                    table.ForeignKey(
                        name: "FK_ReservationsExtraServices_ExtraServices_ExtraServiceId",
                        column: x => x.ExtraServiceId,
                        principalTable: "ExtraServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationsExtraServices_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single room" },
                    { 2, "Double room" },
                    { 3, "Family room" },
                    { 4, "Deluxe room" },
                    { 5, "Presidential suite" }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReservationId",
                table: "Payments",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestId",
                table: "Reservations",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsExtraServices_ExtraServiceId",
                table: "ReservationsExtraServices",
                column: "ExtraServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CategoryId",
                table: "Rooms",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsAvailabilities_RoomId",
                table: "RoomsAvailabilities",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ReservationsExtraServices");

            migrationBuilder.DropTable(
                name: "RoomsAvailabilities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExtraServices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
