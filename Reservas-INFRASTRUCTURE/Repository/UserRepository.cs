using Microsoft.EntityFrameworkCore;
using Reservas_DOMAIN.AggregateModels.UserAggregate;
using Reservas_DOMAIN.SeedWork;


namespace Reservas_INFRASTRUCTURE.Repository
{
    public class UserRepository: IUserRepository
    {

        private readonly ReservasDbContext _context;

        public UserRepository(ReservasDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public User Add(User user)
        {
            return _context.Users.Add(user).Entity;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
