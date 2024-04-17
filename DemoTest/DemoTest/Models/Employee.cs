using System;
using System.Collections.Generic;

namespace DemoTest.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string? FirstName { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? Phone { get; set; }

    public string? Adress { get; set; }

    public string? Passport { get; set; }

    public int? IdStatus { get; set; }

    public int? IdPosition { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual Position? IdPositionNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    public string PostName
    {
        get
        {
            Position position = App.context.Positions.ToList().Find(u => u.IdPosition == this.IdPosition);
            return position.Name;
        }
    }
    public string StatusName 
    {
        get
        {
            Status status = App.context.Statuses.ToList().Find(u=>u.IdStatus == this.IdStatus);
            return status.Name;
        }
    }
    public string SNP
    {
        get
        {
            return $"{FirstName}{Name}{Patronymic}";
        }
    }
}
