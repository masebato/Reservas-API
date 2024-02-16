using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;

namespace Reservas_INFRASTRUCTURE.Models;

public partial class User : IDto
{
    public int Userid { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
