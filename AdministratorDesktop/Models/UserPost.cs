using System;
using System.Collections.Generic;

namespace AdministratorDesktop.Models;

public partial class UserPost
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
