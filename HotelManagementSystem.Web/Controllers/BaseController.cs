using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.Infrastructure.Extensions;
using static HotelManagementSystem.Common.ApplicationConstants;
using Microsoft.AspNetCore.Mvc;
using static HotelManagementSystem.Common.EntityValidationConstants;

namespace HotelManagementSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUserService userService;

        public BaseController(IUserService userService)
        {
            this.userService = userService;
        }

        protected bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            // Non-existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // Invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }

        protected async Task<bool> IsUserReceptionistAsync()
        {
            string? userId = this.User.GetId();
            if (userId == null)
            {
                return false;
            }
            bool isReceptionist = await this.userService
                .IsUserReceptionistAsync(userId);

            return isReceptionist;
        }

        protected async Task AppendUserCookieAsync()
        {
            bool isReceptionist = await this.IsUserReceptionistAsync();

            this.HttpContext.Response.Cookies.Append(IsReceptionistCookieName, isReceptionist.ToString());
        }
    }
}
