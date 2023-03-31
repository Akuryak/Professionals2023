using System;
using System.Collections.Generic;

namespace AdministratorDesktop.Models;

public partial class UserType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();

    public UserType()
    {
    }

    public UserType(int id, string name, ICollection<User> users)
    {
        Id = id;
        Name = name;
        Users = users;
    }
}
