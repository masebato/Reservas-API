using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_DOMAIN.AggregateModels.GuestAggregate
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Guest Add(Guest guest);
        void Update(Guest guest);      

    }
}
