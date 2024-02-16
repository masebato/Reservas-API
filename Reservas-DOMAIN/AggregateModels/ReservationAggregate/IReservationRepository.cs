using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_DOMAIN.AggregateModels.ReservationAggregate
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Reservation Add(Reservation reservation);
        void Update(Reservation reservation);
    }
}
