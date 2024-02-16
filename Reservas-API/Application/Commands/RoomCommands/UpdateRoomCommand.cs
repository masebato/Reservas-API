using FluentValidation;
using MediatR;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using Reservas_INFRASTRUCTURE.Repository;

namespace Reservas_API.Application.Commands.RoomCommands
{
    public class UpdateRoomCommand: IRequest<bool>
    {

        public int Id { get; set; }
        public string Number { get;  set; }
        public decimal BaseCost { get;  set; }
        public decimal Taxes { get;  set; }
        public string Type { get;  set; }
        public bool Status { get;  set; }
        public string Location { get;  set; }

        public UpdateRoomCommand(int id, string number, decimal baseCost, decimal taxes, string type, bool status, string location)
        {
            Id = id;
            Number = number;
            BaseCost = baseCost;
            Taxes = taxes;
            Type = type;
            Status = status;
            Location = location;
        }

        public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
        {
            public UpdateRoomCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
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
