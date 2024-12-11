using HotelManagementSystem.Web.ViewModels.ExtraService;

namespace HotelManagementSystem.Services.Data.Interfaces
{
    public interface IExtraServiceService
    {
        Task<IEnumerable<ExtraServiceIndexViewModel>> GetAllAsync();
        Task<IEnumerable<AddToReservationFormModel>> AddToReservationAsync(string reservationId);
    }
}
