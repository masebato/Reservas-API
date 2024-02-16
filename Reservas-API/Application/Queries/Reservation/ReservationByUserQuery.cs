using MediatR;
using Reservas_DOMAIN.DTOs;

namespace Reservas_API.Application.Queries.Reservation
{
    public class ReservationByUserQuery : IRequest<IList<ReservationByUserDto>>
    {

        public int  UserId { get; set; }
              
        public ReservationByUserQuery(int userId) { UserId = userId;}

    }
}
