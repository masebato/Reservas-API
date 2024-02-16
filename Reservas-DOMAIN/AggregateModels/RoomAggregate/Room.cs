using Reservas_DOMAIN.AggregateModels.HotelAggregate;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.SeedWork;


namespace Reservas_DOMAIN.AggregateModels.RoomAggregate
{
    public class Room : Entity, IAggregateRoot
    {
        public int HotelId { get;  set; }
        public string Number { get;  set; }
        public decimal BaseCost { get;  set; }
        public decimal Taxes { get;  set; }
        public string Type { get;  set; }
        public bool Status { get;  set; }
        public string Location { get;  set; }
        public virtual Hotel? Hotel { get;  set; }
        public virtual ICollection<Reservation>? Reservations { get;  set; }

        public Room()
        {
        }
        public Room(int hotelId, string number, decimal baseCost, decimal taxes, string type, bool status, string location)
        {
            HotelId = hotelId;
            Number = number;
            BaseCost = baseCost;
            Taxes = taxes;
            Type = type;
            Status = status;
            Location = location;
        }

        public Room(string number, decimal baseCost, decimal taxes, string type, bool status, string location)
        {
          
            Number = number;
            BaseCost = baseCost;
            Taxes = taxes;
            Type = type;
            Status = status;
            Location = location;
        }

        public void UpdateStatus()
        {
            this.Status = !this.Status;
        }   
    }
}
