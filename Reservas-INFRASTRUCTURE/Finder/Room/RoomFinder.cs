﻿using Dapper;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using System.Data;
using Reservas_INFRASTRUCTURE.Finder.Util;
using Reservas_DOMAIN.Exception;
using Reservas_API.Application.DTOs;
using Reservas_INFRASTRUCTURE.Models;

namespace Reservas_INFRASTRUCTURE.Finder.Room
{
    public class RoomFinder: IRoomFinder
    {

        private readonly IDbConnection _dbConnection;

        public RoomFinder(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<IList<FindRoomDTO>> GetRoomByDate(DateTime initialDate, DateTime finalDate)
        {
            var sql = SQLreader.GetQuery("get-room-by-date").Result;
            var dictionary = new Dictionary<string, object>
            {
                { "@initialDate", initialDate },
                { "@finalDate", finalDate },

            };

            var parameters = new DynamicParameters(dictionary);

            var room = await _dbConnection.QueryAsync<FindRoomDTO>(sql, parameters);

            if (room == null) throw new BadRequestException("There are no Room available");


            return room.ToList(); 
        }

        public async Task<FindRoomDTO> GetRoomById(int roomId)
        {
            try
            {
                var sql = SQLreader.GetQuery("get-room-by-id").Result;
                var dictionary = new Dictionary<string, object>
                {
                    { "@id", roomId },
                };
                var parameters = new DynamicParameters(dictionary);

                var room = await _dbConnection.QueryFirstAsync<FindRoomDTO>(sql, parameters);
                if (room == null) throw new BadRequestException("There are no Room available");


                return room;

            }
            catch (Exception)
            {

                throw new BadRequestException("There are not Room found");
            }
           
          
          
        }

    }
}
