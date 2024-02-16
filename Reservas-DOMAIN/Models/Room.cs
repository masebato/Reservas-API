using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;

namespace Reservas_INFRASTRUCTURE.Models;

public partial class Room : IDto
{
    public int Roomid { get; set; }

    public int? Hotelid { get; set; }

    public string? Number { get; set; }

    public decimal? Basecost { get; set; }

    public decimal? Taxes { get; set; }

    public string? Type { get; set; }

    public bool? Status { get; set; }

    public string? Location { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
