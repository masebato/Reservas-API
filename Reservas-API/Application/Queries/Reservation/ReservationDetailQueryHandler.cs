using MediatR;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.DTOs;

namespace Reservas_API.Application.Queries.Reservation
{
    public class ReservationDetailQueryHandler : IRequestHandler<ReservationDetailQuery, ReservationDetailByIdDto>
    {

        private readonly IReservationFinder _reservationFinder;


        public ReservationDetailQueryHandler(IReservationFinder reservationFinder)
        {
            _reservationFinder = reservationFinder;
        }

        public async Task<ReservationDetailByIdDto> Handle(ReservationDetailQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationFinder.GetReservationDetailById(request.Id);
            if (reservation != null)
            {
                return reservation;
            }
            throw new Exception("Reserva no encontrada");
        }

    }
   
}
