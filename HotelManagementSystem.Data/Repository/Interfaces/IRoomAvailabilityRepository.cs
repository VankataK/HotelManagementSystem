using HotelManagementSystem.Data.Models;

namespace HotelManagementSystem.Data.Repository.Interfaces
{
    public interface IRoomAvailabilityRepository : IRepository<RoomAvailability, Guid>
    {
        Task<bool> IsAvailableAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate);
        Task BlockRoomDatesAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate);
        Task FreeRoomDatesAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate);
        Task<List<DateTime>> GetUnavailableDatesAsync(Guid roomId);
    }
}
