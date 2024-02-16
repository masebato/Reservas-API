using Reservas_API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_DOMAIN.AggregateModels.RoomAggregate
{
    public interface IRoomFinder
    {
        Task<FindRoomDTO> GetRoomById(int roomId);
    }
}
