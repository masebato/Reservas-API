using MediatR;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;

namespace Reservas_API.Application.Commands.RoomCommands
{
    public class UpdateStatusRoomCommandHandler : IRequestHandler<UpdateStatusRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;
       

     public UpdateStatusRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
          
        }

        public async Task<bool> Handle(UpdateStatusRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomById(request.Id);
          

            room.UpdateStatus(); 

            _roomRepository.Update(room);
            var saveOk = await _roomRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return saveOk;
        }

        
    }
}
