using System;
using System.Collections.Generic;

namespace Team_3_BucHunt_WebApp.Models;

public partial class HuntCode
{
    public int HuntId { get; set; }

    public string Code { get; set; } = null!;

    public int? UseCount { get; set; }

    public int? MaxCount { get; set; }

    public virtual Hunt Hunt { get; set; } = null!;
}
