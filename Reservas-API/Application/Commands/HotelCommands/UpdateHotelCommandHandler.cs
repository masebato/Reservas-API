using MediatR;
using Reservas_DOMAIN.AggregateModels.HotelAggregate;

namespace Reservas_API.Application.Commands.HotelCommands
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, bool>
    {
        private readonly IHotelRepository _hotelRepository;

        public UpdateHotelCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<bool> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetHotelById(request.Id);
            if(hotel!=null)
            {
                hotel.Name = request.Name ?? hotel.Name;
                hotel.Address = request.Address ?? hotel.Address;
                hotel.Rating = request.Rating ?? hotel.Rating;               
                hotel.City = request.City ?? hotel.City;
                hotel.Rating = request.Rating ?? hotel.Rating;
                hotel.Status = request.Status ?? hotel.Status;

                _hotelRepository.Update(hotel);
                var saveOk = await _hotelRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                if(saveOk)
                {
                    return saveOk;
                }
            }
            throw new Exception("Error al actualizar el hotel");
        }
    }
  
}
