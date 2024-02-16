using Dapper;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.DTOs;
using Reservas_DOMAIN.Exception;
using Reservas_INFRASTRUCTURE.Finder.Util;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_INFRASTRUCTURE.Finder.Reservation
{
    public class ReservationFinder : IReservationFinder
    {

        private readonly IDbConnection _dbConnection;

        public ReservationFinder(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }   

        public async Task<IList<ReservationByUserDto>> GetReservationByIdUser(int userId)
        {

            var sql = SQLreader.GetQuery("get-reservations-by-user").Result;
            var dictionary = new Dictionary<string, object>
            {

            { "@id", userId },
            };
            var parameters = new DynamicParameters(dictionary);

            var reservation = await _dbConnection.QueryAsync<ReservationByUserDto, GuestDto, ReservationByUserDto>(sql, (reservation, guest) => 
            { 
                reservation.Guests.Add(guest);

                return reservation;
            
            }, parameters, splitOn: "Id,GuestId");

            if (reservation == null) throw new EntityNotFoundException(userId, nameof(reservation));

            return reservation.ToList();
        }


        public async Task<ReservationDetailByIdDto> GetReservationDetailById(int reservationId)
        {

            var sql = SQLreader.GetQuery("get-detail-reservation-by-id").Result;
            var dictionary = new Dictionary<string, object>
            {

            { "@id", reservationId },
            };
            var parameters = new DynamicParameters(dictionary);

            var reservation = await _dbConnection.QueryAsync<ReservationDetailByIdDto, GuestDto, ReservationDetailByIdDto>(sql, (reservation, guest) =>
            {
                reservation.Guests.Add(guest);

                return reservation;

            }, parameters, splitOn: "ReservationId,HotelId,RoomId,EmergencyId,Id");

            if (reservation == null) throw new EntityNotFoundException(reservationId, nameof(reservation));

            return reservation.FirstOrDefault();
        }
    }
}
