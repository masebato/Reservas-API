using MediatR;
using Reservas_API.Application.DTOs;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;

namespace Reservas_API.Application.Queries.Room
{
    public class RoomByIdQueryHandler : IRequestHandler<RoomByIdQuery, FindRoomDTO>
    {

        private readonly IRoomFinder _roomFinder;

        public RoomByIdQueryHandler(IRoomFinder roomFinder)
        {
            _roomFinder = roomFinder;
        }

        public async Task<FindRoomDTO> Handle(RoomByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _roomFinder.GetRoomById(request.RoomId);

            if (result == null)
                throw new Exception("Room not found");

            return result;
        }
    }
}
