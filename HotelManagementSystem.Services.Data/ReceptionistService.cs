using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Data.Repository.Interfaces;
using HotelManagementSystem.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Services.Data
{
    public class ReceptionistService : BaseService, IReceptionistService
    {
        private readonly IRepository<Receptionist, Guid> receptionistRepository;

        public ReceptionistService(IRepository<Receptionist, Guid> receptionistRepository)
        {
            this.receptionistRepository = receptionistRepository;
        }

        public async Task<bool> IsUserReceptionistAsync(string? userId)
        {
            if (String.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            bool result = await this.receptionistRepository
                .GetAllAttached()
                .AnyAsync(m => m.UserId.ToString().ToLower() == userId);

            return result;
        }
    }
}
