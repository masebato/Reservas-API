using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.SeedWork;

namespace Reservas_DOMAIN.AggregateModels.GuestAggregate
{
    public class Guest : Entity
    {
        public int? ReservationId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? DocumentType { get; set; }

        public string? DocumentNumber { get; set; }

        public string? Email { get; set; }

        public string? ContactPhone { get; set; }

        public virtual Reservation? Reservation { get; set; }

      public Guest( string? firstName, string? lastName, DateTime? dateOfBirth, string? gender, string? documentType, string? documentNumber, string? email, string? contactPhone)
        {
          
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            Email = email;
            ContactPhone = contactPhone;
        
        }
    }
}
