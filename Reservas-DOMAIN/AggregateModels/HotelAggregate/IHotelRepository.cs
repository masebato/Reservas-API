using Reservas_DOMAIN.SeedWork;


namespace Reservas_DOMAIN.AggregateModels.HotelAggregate
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Hotel Add(Hotel hotel);
        void Update(Hotel hotel);

        Task<Hotel> GetHotelById(int hotelId);

    }
}
