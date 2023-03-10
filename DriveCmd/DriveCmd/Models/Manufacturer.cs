using System;
using System.Collections.Generic;

namespace DriveCmd.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;
}
