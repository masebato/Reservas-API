using FluentValidation;
using MediatR;
using Reservas_API.Application.DTOs;
using Reservas_INFRASTRUCTURE.Models;

namespace Reservas_API.Application.Queries.Room
{
    public class RoomByIdQuery : IRequest<FindRoomDTO>
    {
        public int RoomId { get; set; }

        public RoomByIdQuery(int id)
        {
            RoomId = id;
        }

        public class RoomByIdQueryValidator : AbstractValidator<RoomByIdQuery>
        {
            public RoomByIdQueryValidator()
            {
                RuleFor(x => x.RoomId).NotEmpty();
            }
        }   
    }
}
