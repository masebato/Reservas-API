using Reservas_DOMAIN.SeedWork;

namespace Reservas_API.Application.DTOs
{
    public class CreateReservationDto : IDto
    {


    }

    public class EmergencyContactDto : IDto
    {      

        public string Fullname { get; set; }

        public string Contactphone { get; set; }

    }


    public class  GuestDto: IDto
    {
       
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string DocumentType { get; set; }

        public string DocumentNumber { get; set; }

        public string Email { get; set; }

        public string ContactPhone { get; set; }

    }
}
