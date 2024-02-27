using MediatR;
using Reservas_API.Application.Constants;
using Reservas_DOMAIN.AggregateModels.EmergencycontactAggregate;
using Reservas_DOMAIN.AggregateModels.GuestAggregate;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using Reservas_DOMAIN.Exception;

namespace Reservas_API.Application.Commands.ReservationCommands
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, bool>
    {

        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomFinder _roomFinder;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository, IRoomFinder roomFinder)
        {
            _reservationRepository = reservationRepository;
            _roomFinder = roomFinder;
        }

        public async Task<bool> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {

            var room = await _roomFinder.GetRoomById(request.RoomId);

            if (!room.Status)
                throw new ReservasException("Room is not available");

            var totalCost = (room.BaseCost + room.Taxes) * (request.CheckOutDate - request.CheckInDate).Days;

            var reservation = new Reservation(request.RoomId, request.UserId, request.CheckInDate, request.CheckOutDate, request.Guests.Count, StatusReservation.Confirmed, totalCost);

            foreach (var guestDto in request.Guests)
            {
                var guest = new Guest(guestDto.FirstName, guestDto.LastName, guestDto.DateOfBirth, guestDto.Gender, guestDto.DocumentType, guestDto.DocumentNumber, guestDto.Email, guestDto.ContactPhone);
                reservation.AddGuest(guest);
            }

            var emergencyContact = new Emergencycontact(request.EmergencyFullName, request.EmergencyContactPhone);
            reservation.AddEmergencyContact(emergencyContact);

            _reservationRepository.Add(reservation);

            var saveOk = await _reservationRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return saveOk;

            return true;
        }
    }
}
