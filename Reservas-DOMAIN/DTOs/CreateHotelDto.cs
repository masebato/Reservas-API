using Reservas_DOMAIN.SeedWork;

namespace Reservas_API.Application.DTOs
{
    public class CreateHotelDto: IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public bool Status { get; set; }
        public List<CreateRoomDto> Rooms { get; set; } = new List<CreateRoomDto>();
    }

    public class CreateRoomDto: IDto
    {
        public string Number { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public string Location { get; set; }
    }
}
