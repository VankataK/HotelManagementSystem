﻿// <auto-generated />
using System;
using HotelManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    [DbContext(typeof(HotelManagmentDbContext))]
    partial class HotelManagmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagementSystem.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("User's first name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("User's last name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Single room"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Double room"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Family room"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Deluxe room"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Presidential suite"
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.ExtraService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Service Identifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Service description");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Service price");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Service name");

                    b.HasKey("Id");

                    b.ToTable("ExtraServices");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d674c587-ce6c-404d-ae3f-8569a55aba98"),
                            Description = "Delicious breakfast served daily.",
                            Price = 30.00m,
                            ServiceName = "Breakfast"
                        },
                        new
                        {
                            Id = new Guid("f969ebdc-85f9-48ba-9905-6b35a871e9d4"),
                            Description = "Comfortable transport to and from the airport.",
                            Price = 50.00m,
                            ServiceName = "Airport Transfer"
                        },
                        new
                        {
                            Id = new Guid("bc948208-dca0-42a1-9efb-467dddd9f79f"),
                            Description = "Relax with our exclusive spa treatments.",
                            Price = 100.00m,
                            ServiceName = "Spa Package"
                        },
                        new
                        {
                            Id = new Guid("e59b1595-81aa-4d28-9e2c-3aa1b779896e"),
                            Description = "Order meals and drinks to your room.",
                            Price = 20.00m,
                            ServiceName = "Room Service"
                        },
                        new
                        {
                            Id = new Guid("ab99f751-a472-4b85-991e-22aec5e0bf68"),
                            Description = "Extend your stay until 2 PM.",
                            Price = 15.00m,
                            ServiceName = "Late Checkout"
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Receptionist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Receptionist Identifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User id of the receptionist");

                    b.Property<string>("WorkPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Receptionist work phone number");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Receptionists");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Reservation Identifier");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2")
                        .HasComment("Check in date");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2")
                        .HasComment("Check out date");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User id of the guest");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of reservation");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Room Identifier");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Reservation price");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.ReservationExtraService", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Reservation Identifier");

                    b.Property<Guid>("ExtraServiceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Service Identifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Amount of service");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Total price for the service");

                    b.HasKey("ReservationId", "ExtraServiceId");

                    b.HasIndex("ExtraServiceId");

                    b.ToTable("ReservationsExtraServices");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Room Identifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category Identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Room description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)")
                        .HasComment("Room image url");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int")
                        .HasComment("Capacity of the room");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Nightly price");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Room number");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a09b20f-c1a7-44d8-97ca-70f71f27f3d6"),
                            CategoryId = 1,
                            Description = "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.",
                            ImageUrl = "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy",
                            IsDeleted = false,
                            MaxCapacity = 1,
                            PricePerNight = 70.00m,
                            RoomNumber = "101"
                        },
                        new
                        {
                            Id = new Guid("97347f36-512e-450e-bbd6-668f5e8f14b4"),
                            CategoryId = 2,
                            Description = "Stylishly designed, this double room offers comfort and functionality for a memorable stay.",
                            ImageUrl = "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg",
                            IsDeleted = false,
                            MaxCapacity = 2,
                            PricePerNight = 120.00m,
                            RoomNumber = "102"
                        },
                        new
                        {
                            Id = new Guid("4920eb5f-0df2-4da4-8007-5dfd6947a6df"),
                            CategoryId = 2,
                            Description = "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.",
                            ImageUrl = "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg",
                            IsDeleted = false,
                            MaxCapacity = 2,
                            PricePerNight = 110.00m,
                            RoomNumber = "103"
                        },
                        new
                        {
                            Id = new Guid("b47e8930-7ff2-433e-a9ed-b8614bc88000"),
                            CategoryId = 3,
                            Description = "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.",
                            ImageUrl = "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png",
                            IsDeleted = false,
                            MaxCapacity = 4,
                            PricePerNight = 250.00m,
                            RoomNumber = "104"
                        },
                        new
                        {
                            Id = new Guid("be60d08e-2ccc-42b2-88bc-b79a50afdfa0"),
                            CategoryId = 5,
                            Description = "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.",
                            ImageUrl = "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg",
                            IsDeleted = false,
                            MaxCapacity = 6,
                            PricePerNight = 7000.00m,
                            RoomNumber = "501"
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.RoomAvailability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("RoomAvailability Identifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasComment("Date of use");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Room Identifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomsAvailabilities");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Receptionist", b =>
                {
                    b.HasOne("HotelManagementSystem.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Reservation", b =>
                {
                    b.HasOne("HotelManagementSystem.Data.Models.ApplicationUser", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HotelManagementSystem.Data.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.ReservationExtraService", b =>
                {
                    b.HasOne("HotelManagementSystem.Data.Models.ExtraService", "ExtraService")
                        .WithMany("ReservationsExtraServices")
                        .HasForeignKey("ExtraServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HotelManagementSystem.Data.Models.Reservation", "Reservation")
                        .WithMany("ReservationsExtraServices")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ExtraService");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Room", b =>
                {
                    b.HasOne("HotelManagementSystem.Data.Models.Category", "Category")
                        .WithMany("Rooms")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.RoomAvailability", b =>
                {
                    b.HasOne("HotelManagementSystem.Data.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("HotelManagementSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("HotelManagementSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagementSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("HotelManagementSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Category", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.ExtraService", b =>
                {
                    b.Navigation("ReservationsExtraServices");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Reservation", b =>
                {
                    b.Navigation("ReservationsExtraServices");
                });

            modelBuilder.Entity("HotelManagementSystem.Data.Models.Room", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
