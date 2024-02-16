using FluentValidation;
using MediatR;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using Reservas_DOMAIN.Exception;

namespace Reservas_API.Application.Commands.RoomCommands
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;

        public UpdateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }

        public async Task<bool> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            
            var room = await _roomRepository.GetRoomById(request.Id);

            if(room!=null)
            {
                room.Location = request.Location;
                room.Number = request.Number;
                room.BaseCost = request.BaseCost;
                room.Taxes = request.Taxes;
                room.Type = request.Type;
                
                _roomRepository.Update(room);
                var saveOk = await _roomRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                return saveOk;

            }

            throw new EntityNotFoundException();
          
        }
    }
}
