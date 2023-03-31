using System;
using System.Collections.Generic;

namespace GeneralDepatmentEemployeesTerminal.Models;

public partial class Visit
{
    public int VisitId { get; set; }

    public int VisitorId { get; set; }

    public DateOnly VisitDate { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Visitor Visitor { get; set; } = null!;
}
