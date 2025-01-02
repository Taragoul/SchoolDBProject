using System;
using System.Collections.Generic;

namespace SchoolDBProject.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Personnel> Teachers { get; set; } = new List<Personnel>();
}
