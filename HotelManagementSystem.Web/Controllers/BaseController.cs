using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.Infrastructure.Extensions;
using static HotelManagementSystem.Common.ApplicationConstants;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IReceptionistService receptionistService;

        public BaseController(IReceptionistService receptionistService)
        {
            this.receptionistService = receptionistService;
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
            bool isReceptionist = await this.receptionistService
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
