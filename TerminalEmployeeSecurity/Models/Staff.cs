using System;
using System.Collections.Generic;

namespace TerminalEmployeeSecurity.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FullName { get; set; } = null!;

    public int? Division { get; set; }

    public int? Department { get; set; }
}
