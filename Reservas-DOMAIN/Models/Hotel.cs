using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;

namespace Reservas_INFRASTRUCTURE.Models;

public partial class Hotel : IDto
{
    public int Hotelid { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public bool? Status { get; set; }

    public int? Rating { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
