using MediatR;
using Reservas_DOMAIN.AggregateModels.HotelAggregate;

namespace Reservas_API.Application.Commands.HotelCommands
{
    public class UpdateStatusHotelCommandHandler : IRequestHandler<UpdateStatusHotelCommand, bool>
    {
        private readonly IHotelRepository _hotelRepository;
        
     public UpdateStatusHotelCommandHandler(IHotelRepository hotelRepository)
        {
         _hotelRepository = hotelRepository;
     }

        public async Task<bool> Handle(UpdateStatusHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetHotelById(request.Id);
            if(hotel!=null)
            {
                hotel.UpdateStatus();
                _hotelRepository.Update(hotel);
                var saveOk = await _hotelRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                if(saveOk)
                {
                    return saveOk;
                }
            }
            throw new Exception("Error al actualizar el estado del hotel");
        }
    }
    
}
