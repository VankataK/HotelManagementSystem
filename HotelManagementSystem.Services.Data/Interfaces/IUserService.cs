using HotelManagementSystem.Web.ViewModels.Admin.UserManagement;

namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();

        Task<bool> UserExistsByIdAsync(Guid userId);

        Task<bool> AssignUserToRoleAsync(Guid userId, string roleName);

        Task<bool> RemoveUserRoleAsync(Guid userId, string roleName);

        Task<bool> DeleteUserAsync(Guid userId);

        Task<string> GetFullNameByEmailAsync(string email);

        Task<string> GetFullNameByIdAsync(Guid userId);

        Task<bool> IsUserReceptionistAsync(string userId);
    }
}
