using MediatR;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;

namespace Reservas_API.Application.Commands.RoomCommands
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Room>
    {

        private readonly IRoomRepository _roomRepository;

        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room(request.HotelId, request.Number, request.BaseCost, request.Taxes, request.Type, request.Status, request.Location);
            _roomRepository.Add(room);
            var saveOk = await _roomRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            if(saveOk)
            {
                return room;
            }

            throw new Exception("Error al guardar la habitación");
        }
    }
}
