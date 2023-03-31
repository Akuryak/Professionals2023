using System;
using System.Collections.Generic;

namespace TestApiDesktop.Models;

public partial class Division
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public Division()
    {
    }

    public Division(int id, string name, ICollection<Request> requests)
    {
        Id = id;
        Name = name;
        Requests = requests;
    }
}
