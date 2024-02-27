using MediatR;
using Reservas_API.Application.DTOs;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;

namespace Reservas_API.Application.Queries.Room
{
    public class RoomBydateQueryHandler : IRequestHandler<RoomByDateQuery, IList<FindRoomDTO>>
    {

        private readonly IRoomFinder _roomFinder;

        public RoomBydateQueryHandler(IRoomFinder roomFinder)
        {
            _roomFinder = roomFinder;
        }


        public async Task<IList<FindRoomDTO>> Handle(RoomByDateQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomFinder.GetRoomByDate(request.initialDate, request.finalDate);
            if (room != null)
            {
                return room;
            }
            throw new Exception("Habitacion no encontrada");
        }   
    }
}
