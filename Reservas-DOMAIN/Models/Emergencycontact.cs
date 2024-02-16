using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;

namespace Reservas_INFRASTRUCTURE.Models;

public partial class Emergencycontact : IDto
{
    public int Emergencycontactid { get; set; }

    public int? Reservationid { get; set; }

    public string? Fullname { get; set; }

    public string? Contactphone { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
