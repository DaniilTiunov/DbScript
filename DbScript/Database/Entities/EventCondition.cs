using System;
using System.Collections.Generic;

namespace DbScript.Database.Entities;

public partial class EventCondition
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;
}
