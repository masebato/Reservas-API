using FluentValidation;
using MediatR;
using Reservas_API.Application.DTOs;

namespace Reservas_API.Application.Queries.Room
{
    public class RoomByDateQuery : IRequest<IList<FindRoomDTO>>
    {

        public DateTime initialDate { get; set; }
        public DateTime finalDate { get; set; }

        public RoomByDateQuery(DateTime initialDate, DateTime finalDate)
        {
            this.initialDate = initialDate;
            this.finalDate = finalDate;
        }

        public class RoomByDateQueryValidator : AbstractValidator<RoomByDateQuery>
        {
            public RoomByDateQueryValidator()
            {
                RuleFor(x => x.initialDate.Date).NotNull().Must(BeAValidDate).WithMessage("La fecha de entrada no es válida");
                RuleFor(x => x.finalDate.Date).NotNull().GreaterThan(x => x.initialDate).WithMessage("La fecha de salida debe ser posterior a la fecha de entrada");
            }
            private bool BeAValidDate(DateTime date)
            {
                return date.Date >= DateTime.Now.Date; // Asegurarse de que la fecha no sea anterior a hoy
            }

        }

    }
}
