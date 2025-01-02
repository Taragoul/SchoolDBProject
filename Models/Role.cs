using System;
using System.Collections.Generic;

namespace SchoolDBProject.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Personnel> Personnel { get; set; } = new List<Personnel>();
}
