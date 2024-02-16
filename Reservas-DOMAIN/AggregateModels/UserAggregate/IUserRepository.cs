using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_DOMAIN.AggregateModels.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {

        User Add(User user);
        void Update(User user);

    }
}
