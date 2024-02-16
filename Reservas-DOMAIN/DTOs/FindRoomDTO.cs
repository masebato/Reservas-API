using Reservas_DOMAIN.SeedWork;

namespace Reservas_API.Application.DTOs
{
    public class FindRoomDTO: IDto
    {
        public int Id { get; set; }
        public string NumberRoom { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }

        public string Location { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelCity { get; set; }
    }
}
