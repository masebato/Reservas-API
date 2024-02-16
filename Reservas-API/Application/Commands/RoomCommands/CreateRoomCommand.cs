using FluentValidation;
using MediatR;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;

namespace Reservas_API.Application.Commands.RoomCommands
{
    public class CreateRoomCommand : IRequest<Room>
    {
        public int HotelId { get; set; }
        public string Number { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public string Location { get; set; }

        public CreateRoomCommand(string number, decimal baseCost, decimal taxes, string type, bool status, string location)
        {
            Number = number;
            BaseCost = baseCost;
            Taxes = taxes;
            Type = type;
            Status = status;
            Location = location;
        }

        public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
        {
            public CreateRoomCommandValidator()
            {
                RuleFor(x => x.Number).NotEmpty();
                RuleFor(x => x.BaseCost).NotEmpty();
                RuleFor(x => x.Taxes).NotEmpty();
                RuleFor(x => x.Type).NotEmpty();
                RuleFor(x => x.Status).NotEmpty();
                RuleFor(x => x.Location).NotEmpty();
            }
        }
    }
}
