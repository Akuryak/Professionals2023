using System;
using System.Collections.Generic;

namespace TestApiDesktop.Models;

public partial class Visit
{
    public int VisitId { get; set; }

    public int VisitorId { get; set; }

    public DateOnly VisitDate { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Visitor Visitor { get; set; } = null!;

    public Visit(int visitId, int visitorId, DateOnly visitDate, int? groupId, Group? group, Visitor visitor)
    {
        VisitId = visitId;
        VisitorId = visitorId;
        VisitDate = visitDate;
        GroupId = groupId;
        Group = group;
        Visitor = visitor;
    }

    public Visit()
    {
    }
}
