using System;
using System.Collections.Generic;

namespace DbScript.Database.Entities;

public partial class EventCategory
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Eventtype { get; set; } = null!;
}
