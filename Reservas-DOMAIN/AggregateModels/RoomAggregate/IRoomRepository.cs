using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_DOMAIN.AggregateModels.RoomAggregate
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room Add(Room room);
        void Update(Room room);     

        Task<Room> GetRoomById(int roomId);


    }
}
