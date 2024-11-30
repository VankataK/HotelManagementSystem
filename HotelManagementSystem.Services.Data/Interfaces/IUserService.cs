namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);

        Task<string> GetFullNameByIdAsync(Guid userId);
    }
}
