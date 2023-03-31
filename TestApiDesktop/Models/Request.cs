using System;
using System.Collections.Generic;

namespace TestApiDesktop.Models;

public partial class Request
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int Division { get; set; }

    public DateTime Datetime { get; set; }

    public int? Status { get; set; }

    public virtual Division DivisionNavigation { get; set; } = null!;

    public virtual Status? StatusNavigation { get; set; }

    public Request()
    {
    }

    public Request(int id, string type, int division, DateTime datetime, int? status, Division divisionNavigation, Status? statusNavigation)
    {
        Id = id;
        Type = type;
        Division = division;
        Datetime = datetime;
        Status = status;
        DivisionNavigation = divisionNavigation;
        StatusNavigation = statusNavigation;
    }
}
