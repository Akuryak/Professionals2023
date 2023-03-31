using System;
using System.Collections.Generic;

namespace TerminalDivisionEmployee.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public DateOnly DateOfCreation { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
