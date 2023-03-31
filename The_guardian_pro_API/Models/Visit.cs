﻿using System;
using System.Collections.Generic;

namespace The_guardian_pro_API.Models;

public partial class Visit
{
    public int VisitId { get; set; }

    public int VisitorId { get; set; }

    public DateTime VisitDate { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Visitor Visitor { get; set; } = null!;
}
