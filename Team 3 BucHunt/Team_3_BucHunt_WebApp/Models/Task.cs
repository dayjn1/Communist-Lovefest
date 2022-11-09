using System;
using System.Collections.Generic;

namespace Team_3_BucHunt_WebApp.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public int LocationId { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }
}
