using System;
using System.Collections.Generic;

namespace TestApiDesktop.Models;

public partial class PurposOfTheVisit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public PurposOfTheVisit(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public PurposOfTheVisit()
    {
    }
}
