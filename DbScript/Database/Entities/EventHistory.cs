using System;
using System.Collections.Generic;

namespace DbScript.Database.Entities;

public partial class EventHistory
{
    public DateTime Time { get; set; }

    public string Source { get; set; } = null!;

    public string Eventtype { get; set; } = null!;

    public string Category { get; set; } = null!;

    public int Severity { get; set; }

    public string Condition { get; set; } = null!;

    public string Subcondition { get; set; } = null!;

    public string Message { get; set; } = null!;

    public short Changemask { get; set; }

    public short Newstate { get; set; }

    public int Quality { get; set; }

    public DateTime Activetime { get; set; }

    public int Cookie { get; set; }

    public string Actorid { get; set; } = null!;

    public string? Ackcomment { get; set; }

    public long? Nodeid { get; set; }

    public Guid Appid { get; set; }
}
