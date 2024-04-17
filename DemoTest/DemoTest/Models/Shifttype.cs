using System;
using System.Collections.Generic;

namespace DemoTest.Models;

public partial class Shifttype
{
    public int IdShiftType { get; set; }

    public string? ShiftName { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
}
