using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data.Models;

namespace HotelManagementSystem.Data
{
    public class HotelManagmentDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public HotelManagmentDbContext()
        {
            
        }

        public HotelManagmentDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Room> Rooms { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Reservation> Reservations { get; set; } = null!;

        public DbSet<ExtraService> ExtraServices { get; set; } = null!;

        public DbSet<ReservationExtraService> ReservationsExtraServices { get; set; } = null!;

        public DbSet<Payment> Payments { get; set; } = null!;

        public DbSet<RoomAvailability> RoomsAvailabilities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
