using System;
using System.Collections.Generic;

namespace DemoTest.Models;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Cost { get; set; }

    public byte[]? Photo { get; set; }

    public int? Quantity { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}
