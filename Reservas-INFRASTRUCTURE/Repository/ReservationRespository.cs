using Microsoft.EntityFrameworkCore;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_INFRASTRUCTURE.Repository
{
    public class ReservationRespository: IReservationRepository
    {

        private readonly ReservasDbContext _context;

        public ReservationRespository(ReservasDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public Reservation Add(Reservation reservation)
        {
            return _context.Reservations.Add(reservation).Entity;
        }
       public void Update(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
        }

    }
}
