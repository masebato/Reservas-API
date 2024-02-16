using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_DOMAIN.DTOs
{
    public class ReservationByUserDto
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalCost { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string NumberRoom { get; set; }
        public string LocationRoom { get; set; }
        public List<GuestDto> Guests { get; set; } = new List<GuestDto>();

    }

   
}
