using MediatR;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.DTOs;

namespace Reservas_API.Application.Queries.Reservation
{
    public class ReservationDetailQuery : IRequest<ReservationDetailByIdDto>
    {

        public int Id { get; set; }

        public ReservationDetailQuery(int id)
        {
            Id = id;
        }

    }
}
   

