using FluentValidation;
using MediatR;

namespace Reservas_API.Application.Commands.HotelCommands
{
    public class UpdateStatusHotelCommand : IRequest<bool>
    {
        public int Id { get; set; }


        public UpdateStatusHotelCommand(int id)
        {
            Id = id;
        }

        public class UpdateStatusHotelCommandValidator : AbstractValidator<UpdateStatusHotelCommand>
        {
            public UpdateStatusHotelCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }
    }
}
