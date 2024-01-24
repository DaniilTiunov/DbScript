using System;
using System.Collections.Generic;

namespace DbScript.Database.Entities;

public partial class Node
{
    public long Nodeid { get; set; }

    public string Tagname { get; set; } = null!;

    public string? Description { get; set; }

    public string? Unit { get; set; }

    public Guid Appid { get; set; }
}
