using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Web.ViewModels.Room
{
    public class AddRoomToReservationViewModel
    {
        public string Id { get; set; } = null!;

        public string RoomNumber { get; set; } = null!;

        public decimal PricePerNight { get; set; }
    }
}
