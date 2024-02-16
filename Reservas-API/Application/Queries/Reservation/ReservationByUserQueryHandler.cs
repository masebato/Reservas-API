using MediatR;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.DTOs;

namespace Reservas_API.Application.Queries.Reservation
{
    public class ReservationByUserQueryHandler : IRequestHandler<ReservationByUserQuery, IList<ReservationByUserDto>>
    {

        private readonly IReservationFinder _reservationFinder;

        public ReservationByUserQueryHandler(IReservationFinder reservationFinder)
        {
            _reservationFinder = reservationFinder;
        }

        public async Task<IList<ReservationByUserDto>> Handle(ReservationByUserQuery request, CancellationToken cancellationToken)
        {
           return  await _reservationFinder.GetReservationByIdUser(request.UserId);

        }
    }
}
