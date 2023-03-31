using Microsoft.AspNetCore.Components.Forms;

namespace WebAPI.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FullName { get; set; } = null!;

    public int? Division { get; set; }

    public int? Department { get; set; }

    public static implicit operator Staff(InputSelect<Division> v)
    {
        throw new NotImplementedException();
    }
}
