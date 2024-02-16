using MediatR;
using Reservas_DOMAIN.AggregateModels.HotelAggregate;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;

namespace Reservas_API.Application.Commands.HotelCommands
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, bool>
    {
        private readonly IHotelRepository _hotelRepository;


        public CreateHotelCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        }

        public async Task<bool> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            
            var hotel = new Hotel(request.Name, request.Address, request.City, request.Status, request.Rating, request.Description);

            
            foreach (var roomDto in request.Rooms)
            {
                var room = new Room(roomDto.Number, roomDto.BaseCost, roomDto.Taxes, roomDto.Type, roomDto.Status, roomDto.Location);
                hotel.AddRoom(room);
            }

           
            _hotelRepository.Add(hotel);

          
            var saveOk = await _hotelRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return saveOk;
        }
    }
}
