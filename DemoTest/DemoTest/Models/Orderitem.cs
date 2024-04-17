using System;
using System.Collections.Generic;

namespace DemoTest.Models;

public partial class Orderitem
{
    public int IdOrderItem { get; set; }

    public int? IdOrder { get; set; }

    public int? IdMenu { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }
}
