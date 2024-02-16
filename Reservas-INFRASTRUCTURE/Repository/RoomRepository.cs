using Microsoft.EntityFrameworkCore;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using Reservas_DOMAIN.Exception;
using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_INFRASTRUCTURE.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ReservasDbContext _context;

        public RoomRepository(ReservasDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public Room Add(Room room)
        {
            return _context.Rooms.Add(room).Entity;
        }


        public void Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
        }
      
        public async Task<Room> GetRoomById(int roomId)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == roomId);

            if (room == null) throw new EntityNotFoundException(roomId, nameof(room));

            await _context.Entry(room).Collection(r => r.Reservations).LoadAsync();

            return room;
        }
    }
}
