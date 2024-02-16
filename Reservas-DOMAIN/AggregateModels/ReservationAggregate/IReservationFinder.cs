using Reservas_DOMAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_DOMAIN.AggregateModels.ReservationAggregate
{
    public interface IReservationFinder
    {

        Task<IList<ReservationByUserDto>> GetReservationByIdUser(int userId);
        Task<ReservationDetailByIdDto> GetReservationDetailById(int reservationId);

    }
}
