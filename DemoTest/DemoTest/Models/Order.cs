using System;
using System.Collections.Generic;

namespace DemoTest.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? IdEmployee { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? OrderStatus { get; set; }

    public decimal? OrderTotalAmount { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}
