using System;
using System.Collections.Generic;

namespace TestApiDesktop.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public DateOnly DateOfCreation { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public Group(int groupId, DateOnly dateOfCreation, string name, ICollection<Visit> visits)
    {
        GroupId = groupId;
        DateOfCreation = dateOfCreation;
        Name = name;
        Visits = visits;
    }

    public Group()
    {
    }
}
