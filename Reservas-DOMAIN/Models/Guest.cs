using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;

namespace Reservas_INFRASTRUCTURE.Models;

public partial class Guest : IDto
{
    public int Guestid { get; set; }

    public int? Reservationid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateOnly? Dateofbirth { get; set; }

    public string? Gender { get; set; }

    public string? Documenttype { get; set; }

    public string? Documentnumber { get; set; }

    public string? Email { get; set; }

    public string? Contactphone { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
