using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Data.Repository
{
    public class RoomAvailabilityRepository : BaseRepository<RoomAvailability, Guid>, IRoomAvailabilityRepository
    {
        public RoomAvailabilityRepository(HotelManagmentDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task BlockRoomDatesAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            var datesToBlock = new List<RoomAvailability>();

            for (var date = checkInDate; date < checkOutDate; date = date.AddDays(1))
            {
                datesToBlock.Add(new RoomAvailability
                {
                    RoomId = roomId,
                    Date = date
                });
            }

            await this.AddRangeAsync(datesToBlock.ToArray());
        }

        public async Task<List<DateTime>> GetUnavailableDatesAsync(Guid roomId)
        {
            return await this.GetAllAttached()
                .Where(a => a.RoomId == roomId)
                .Select(a => a.Date)
                .ToListAsync();
        }

        public async Task<bool> IsAvailableAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            return !await this.GetAllAttached()
                .AnyAsync(a => a.RoomId == roomId && a.Date >= checkInDate && a.Date < checkOutDate);
        }
    }
}
