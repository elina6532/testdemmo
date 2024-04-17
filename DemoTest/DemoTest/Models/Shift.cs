using System;
using System.Collections.Generic;

namespace DemoTest.Models;

public partial class Shift
{
    public int IdShift { get; set; }

    public int? IdEmployee { get; set; }

    public int? IdShiftType { get; set; }

    public DateOnly? ShidtDate { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual Shifttype? IdShiftTypeNavigation { get; set; }
}
