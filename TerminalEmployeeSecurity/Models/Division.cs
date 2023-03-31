using System;
using System.Collections.Generic;

namespace TerminalEmployeeSecurity.Models;

public partial class Division
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
