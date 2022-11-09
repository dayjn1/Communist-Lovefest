using System;
using System.Collections.Generic;

namespace Team_3_BucHunt_WebApp.Models;

public partial class Hunt
{
    public int HuntId { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public bool? TeamGame { get; set; }

    public virtual ICollection<HuntCode> HuntCodes { get; } = new List<HuntCode>();

    public virtual ICollection<User> UsersNavigation { get; } = new List<User>();

    public virtual ICollection<Location> Locations { get; } = new List<Location>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
