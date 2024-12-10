namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IReceptionistService
    {
        Task<bool> IsUserReceptionistAsync(string? userId);
    }
}
