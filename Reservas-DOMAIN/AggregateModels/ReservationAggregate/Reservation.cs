using Reservas_DOMAIN.AggregateModels.EmergencycontactAggregate;
using Reservas_DOMAIN.AggregateModels.GuestAggregate;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using Reservas_DOMAIN.AggregateModels.UserAggregate;
using Reservas_DOMAIN.SeedWork;


namespace Reservas_DOMAIN.AggregateModels.ReservationAggregate
{
    public class Reservation: Entity, IAggregateRoot
    {
        public int? RoomId { get; set; }

        public int? UserId { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        public int? NumberOfGuests { get; set; }

        public string? Status { get; set; }

        public decimal? TotalCost { get; set; }

        public virtual ICollection<Emergencycontact> Emergencycontacts { get; } = new List<Emergencycontact>();

        public virtual ICollection<Guest> Guests { get; } = new List<Guest>();

        public virtual Room? Room { get; set; }

        public virtual User? User { get; set; }

        public Reservation()
        {
        }
        public Reservation(int roomId, int userId, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests, string status, decimal totalCost)
        {
            RoomId = roomId;
            UserId = userId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            NumberOfGuests = numberOfGuests;
            Status = status;
            TotalCost = totalCost;
        }

        public void AddGuest(Guest guest)
        {
            Guests.Add(guest);
        }

        public void AddEmergencyContact(Emergencycontact emergencycontact)
        {
            Emergencycontacts.Add(emergencycontact);
        }
    }
}
