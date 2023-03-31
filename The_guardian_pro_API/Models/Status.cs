using System;
using System.Collections.Generic;

namespace The_guardian_pro_API.Models;

public partial class Status
{
    public int Id { get; set; }

    public sbyte Status1 { get; set; }

    public string Discription { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
