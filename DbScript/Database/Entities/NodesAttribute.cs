using System;
using System.Collections.Generic;

namespace DbScript.Database.Entities;

public partial class NodesAttribute
{
    public long Nodeid { get; set; }

    public long Propid { get; set; }

    public long? Valint { get; set; }

    public long? Valuint { get; set; }

    public double? Valdouble { get; set; }

    public bool? Valbool { get; set; }

    public string? Valstring { get; set; }

    public Guid Appid { get; set; }
}
