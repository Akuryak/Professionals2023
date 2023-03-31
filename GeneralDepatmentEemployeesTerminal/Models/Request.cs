using System;
using System.Collections.Generic;

namespace GeneralDepatmentEemployeesTerminal.Models;

public partial class Request
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int Division { get; set; }

    public int VisitorId { get; set; }

    public int? GroupId { get; set; }

    public DateTime Datetime { get; set; }

    public int? Status { get; set; }

    public virtual Division DivisionNavigation { get; set; } = null!;

    public virtual Group? Group { get; set; }

    public virtual Status? StatusNavigation { get; set; }

    public virtual Visitor Visitor { get; set; } = null!;
}
