using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_DOMAIN.DTOs
{
    public class ReservationDetailByIdDto
    {

        public int ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalCost { get; set; }
        public int BaseCost { get; set; }
        public int Taxes { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string NumberRoom { get; set; }
        public string LocationRoom { get; set; }
        public int RoomId { get; set; }
        public string TypeRoom { get; set; }
        public int EmergencyId { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }



        public List<GuestDto> Guests { get; set; } = new List<GuestDto>();
    }

}
