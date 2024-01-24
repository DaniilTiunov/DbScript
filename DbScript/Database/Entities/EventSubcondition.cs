using System;
using System.Collections.Generic;

namespace DbScript.Database.Entities;

public partial class EventSubcondition
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Condition { get; set; } = null!;
}
