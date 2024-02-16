using Microsoft.EntityFrameworkCore;
using Reservas_DOMAIN.AggregateModels.HotelAggregate;
using Reservas_DOMAIN.SeedWork;

namespace Reservas_INFRASTRUCTURE.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ReservasDbContext _context;
        public HotelRepository(ReservasDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public IUnitOfWork UnitOfWork => _context;


        public Hotel Add(Hotel hotel)
        {
            return _context.Hotels.Add(hotel).Entity;
        }

        public void Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
        }

        public Task<Hotel> GetHotelById(int hotelId)
        {
            return _context.Hotels.FirstOrDefaultAsync(x => x.Id == hotelId);
        }
    }
}
