using FluentValidation;
using MediatR;
using Reservas_API.Application.DTOs;
using System.Text.RegularExpressions;

namespace Reservas_API.Application.Commands.ReservationCommands
{
    public class CreateReservationCommand : IRequest<bool>
    {

        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }   
        public string Status { get; set; }
    
        public string EmergencyFullName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public List <GuestDto> Guests { get; set; }

 


        public CreateReservationCommand() { }

        public CreateReservationCommand(int roomId, int userId, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests, string status, decimal totalCost, string fullName, string contactPhone, List<GuestDto> guests)
        {
            RoomId = roomId;
            UserId = userId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;         
            Status = status;           
            EmergencyFullName = fullName;
            EmergencyContactPhone = contactPhone;
            Guests = guests;
        }
        public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
        {
            public CreateReservationCommandValidator()
            {
                RuleFor(x => x.RoomId).GreaterThan(0);
                RuleFor(x => x.UserId).GreaterThan(0);
                RuleFor(x => x.CheckInDate.Date).NotNull().Must(BeAValidDate).WithMessage("La fecha de entrada no es válida");
                RuleFor(x => x.CheckOutDate.Date).NotNull().GreaterThan(x => x.CheckInDate).WithMessage("La fecha de salida debe ser posterior a la fecha de entrada");             
                RuleFor(x => x.Status).NotNull().Must(status => new[] { "RESERVADO", "CANCELADO" }.Contains(status)).WithMessage("Estado no válido");              
                RuleFor(x => x.EmergencyFullName).NotNull().NotEmpty().Length(2, 100);
                RuleFor(x => x.EmergencyContactPhone).NotNull().NotEmpty().Matches(new Regex(@"^\+?\d{0,15}$")).WithMessage("Número de teléfono no válido");
                RuleForEach(x => x.Guests).ChildRules(guests =>
                {
                    guests.RuleFor(guest => guest.FirstName).NotNull().NotEmpty().WithMessage("El nombre del huésped es obligatorio");
                    guests.RuleFor(guest => guest.LastName).NotNull().NotEmpty().WithMessage("El apellido del huésped es obligatorio");
                    guests.RuleFor(guest => guest.DateOfBirth.Date)
                        .Must(BeAValidAge)
                        .WithMessage("La edad del huésped debe ser válida y mayor de 18 años");
                    guests.RuleFor(guest => guest.Gender)
                        .NotNull().NotEmpty()
                        .Must(gender => new[] { "MASCULINO", "FEMENINO", "OTRO" }.Contains(gender))
                        .WithMessage("Género no válido");
                    guests.RuleFor(guest => guest.DocumentType)
                        .NotNull().NotEmpty()
                       .Must(type => new[] { "CEDULA", "PASAPORTE", "OTRO" }.Contains(type));
                    guests.RuleFor(guest => guest.DocumentNumber)
                        .NotNull().NotEmpty()
                        .Matches(new Regex(@"^\d{8,10}$"))
                        .WithMessage("Número de documento no válido");
                    guests.RuleFor(guest => guest.Email)
                        .NotNull().NotEmpty().EmailAddress()
                        .WithMessage("Correo electrónico no válido");
                    guests.RuleFor(guest => guest.ContactPhone)
                        .NotNull().NotEmpty()
                        .Matches(new Regex(@"^\+?\d{0,15}$"))
                        .WithMessage("Número de teléfono no válido");
                });
            }

            private bool BeAValidAge(DateTime dateOfBirth)
            {
                var today =DateTime.Today;
                int age = today.Year - dateOfBirth.Year;
                if (dateOfBirth > today.AddYears(-age)) age--;
                return age >= 18;
            }

            private bool BeAValidDate(DateTime date)
            {
                return date.Date >= DateTime.Now.Date; // Asegurarse de que la fecha no sea anterior a hoy
            }
        }
    }
}
