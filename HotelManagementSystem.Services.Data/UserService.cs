using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Services.Data.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HotelManagementSystem.Services.Data
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public UserService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await userManager.FindByNameAsync(email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<string> GetFullNameByIdAsync(Guid userId)
        {
            ApplicationUser? user = await this.userManager
                .FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
