using System;
using System.Collections.Generic;

namespace The_guardian_pro_API.Models;

public partial class Visitor
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public string? VisitorPassport { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Login { get; set; }

    public string Password { get; set; } = null!;

    public sbyte Blacklist { get; set; }

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
