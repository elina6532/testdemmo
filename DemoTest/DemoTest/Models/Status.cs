using System;
using System.Collections.Generic;

namespace DemoTest.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
