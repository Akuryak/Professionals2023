using System;
using System.Collections.Generic;

namespace TestApiDesktop.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FullName { get; set; } = null!;

    public int? Division { get; set; }

    public int? Department { get; set; }

    public Staff(int staffId, string fullName, int? division, int? department)
    {
        StaffId = staffId;
        FullName = fullName;
        Division = division;
        Department = department;
    }

    public Staff()
    {
    }
}
