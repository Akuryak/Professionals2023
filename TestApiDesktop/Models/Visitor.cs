using System;
using System.Collections.Generic;

namespace TestApiDesktop.Models;

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

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public Visitor(int id, string? fullName, string? phoneNumber, string email, string? visitorPassport, DateOnly? birthdate, string? login, string password, ICollection<Visit> visits)
    {
        Id = id;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        VisitorPassport = visitorPassport;
        Birthdate = birthdate;
        Login = login;
        Password = password;
        Visits = visits;
    }

    public Visitor()
    {
    }
}
