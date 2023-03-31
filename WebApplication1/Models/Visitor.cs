namespace WebAPI.Models;

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

    public Visitor()
    {
    }

    public Visitor(int id, string? fullName, string? phoneNumber, string email, string? visitorPassport, DateOnly? birthdate, string? login, string password, sbyte blacklist, ICollection<Request> requests, ICollection<Visit> visits)
    {
        Id = id;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        VisitorPassport = visitorPassport;
        Birthdate = birthdate;
        Login = login;
        Password = password;
        Blacklist = blacklist;
        Requests = requests;
        Visits = visits;
    }
}
