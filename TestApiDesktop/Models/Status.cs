using System;
using System.Collections.Generic;

namespace TestApiDesktop.Models;

public partial class Status
{
    public int Id { get; set; }

    public sbyte Status1 { get; set; }

    public string Discription { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public Status()
    {
    }

    public Status(int id, sbyte status1, string discription, ICollection<Request> requests)
    {
        Id = id;
        Status1 = status1;
        Discription = discription;
        Requests = requests;
    }
}
