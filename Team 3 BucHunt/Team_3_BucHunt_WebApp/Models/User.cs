using System;
using System.Collections.Generic;

namespace Team_3_BucHunt_WebApp.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNum { get; set; } = null!;

    public string? AccessCode { get; set; }

    public int? HuntId { get; set; }

    public virtual Hunt? Hunt { get; set; }

    public virtual ICollection<Hunt> Hunts { get; } = new List<Hunt>();
}
