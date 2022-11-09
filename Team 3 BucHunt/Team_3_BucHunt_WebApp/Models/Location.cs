using System;
using System.Collections.Generic;

namespace Team_3_BucHunt_WebApp.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public double? Long { get; set; }

    public double? Lat { get; set; }

    public virtual ICollection<Hunt> Hunts { get; } = new List<Hunt>();
}
