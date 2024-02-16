using FluentValidation;
using MediatR;

namespace Reservas_API.Application.Commands.RoomCommands
{
    public class UpdateStatusRoomCommand : IRequest<bool>
    {

        public int Id { get; set; }
       
        public UpdateStatusRoomCommand(int id )
        {
            Id = id;            
        }
       
        public class UpdateStatusRoomCommandValidator : AbstractValidator<UpdateStatusRoomCommand>
        {
            public UpdateStatusRoomCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }   
    }
}
