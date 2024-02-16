using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.SeedWork;


namespace Reservas_DOMAIN.AggregateModels.EmergencycontactAggregate
{
    public class Emergencycontact: Entity
    {
        
        public int? ReservationId { get; set; }

        public string? FullName { get; set; }

        public string? ContactPhone { get; set; }

        public virtual Reservation? Reservation { get; set; }

        public Emergencycontact( string? fullName, string? contactPhone)
        {
          
            FullName = fullName;
            ContactPhone = contactPhone;
        }
    }
}
