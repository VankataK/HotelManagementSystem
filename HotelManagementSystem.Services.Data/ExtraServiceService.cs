using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Data.Repository.Interfaces;
using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Web.ViewModels.ExtraService;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Services.Data
{
    public class ExtraServiceService : BaseService, IExtraServiceService
    {
        private readonly IRepository<ExtraService, Guid> extraServiceService;

        public ExtraServiceService(IRepository<ExtraService, Guid> extraServiceService)
        {
            this.extraServiceService = extraServiceService;
        }

        public Task<IEnumerable<AddToReservationFormModel>> AddToReservationAsync(string reservationId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExtraServiceIndexViewModel>> GetAllAsync()
        {
            IEnumerable<ExtraServiceIndexViewModel> extraServices = await this.extraServiceService
                .GetAllAttached()
                .Select(r => new ExtraServiceIndexViewModel()
                {
                    Id = r.Id.ToString(),
                    ServiceName = r.ServiceName,
                    Price = r.Price,
                })
                .ToListAsync();

            return extraServices;
        }
    }
}
