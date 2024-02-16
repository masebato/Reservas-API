using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;

namespace Reservas_INFRASTRUCTURE.Models;

public partial class Reservation : IDto
{
    public int Reservationid { get; set; }

    public int? Roomid { get; set; }

    public int? Userid { get; set; }

    public DateOnly? Checkindate { get; set; }

    public DateOnly? Checkoutdate { get; set; }

    public int? Numberofguests { get; set; }

    public string? Status { get; set; }

    public decimal? Totalcost { get; set; }

    public virtual ICollection<Emergencycontact> Emergencycontacts { get; } = new List<Emergencycontact>();

    public virtual ICollection<Guest> Guests { get; } = new List<Guest>();

    public virtual Room? Room { get; set; }

    public virtual User? User { get; set; }
}
