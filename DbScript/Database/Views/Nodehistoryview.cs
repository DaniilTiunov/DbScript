using System;
using System.Collections.Generic;

namespace DbScript.Database.Views;

public partial class Nodehistoryview
{
    public string? Tagname { get; set; }

    public DateTime? Actualtime { get; set; }

    public DateTime? Time { get; set; }

    public double? Valdouble { get; set; }

    public long? Valint { get; set; }

    public long? Valuint { get; set; }
}
