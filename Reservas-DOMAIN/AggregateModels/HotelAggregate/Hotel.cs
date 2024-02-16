using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using Reservas_DOMAIN.SeedWork;


namespace Reservas_DOMAIN.AggregateModels.HotelAggregate
{
    public class Hotel : Entity, IAggregateRoot
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public bool? Status { get; set; }

        public int? Rating { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Room> Rooms { get; } = new List<Room>();
        public Hotel(string name, string address, string city, bool status, int rating, string description)
        {
            Name = name;
            Address = address;
            City = city;
            Status = status;
            Rating = rating;
            Description = description;
        }

        public Hotel()
        {
            Rooms = new List<Room>();
        }

        public void AddRoom(Room rooms)
        {             
            Rooms.Add(rooms);
        }

        public void UpdateStatus()
        {
            this.Status = !this.Status;
        }

    }
}
