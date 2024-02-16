using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.SeedWork;


namespace Reservas_DOMAIN.AggregateModels.UserAggregate
{
    public class User: Entity
    {

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();


        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
          
        }

    }
}
