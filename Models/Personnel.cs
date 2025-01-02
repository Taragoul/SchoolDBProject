using System;
using System.Collections.Generic;

namespace SchoolDBProject.Models;

public partial class Personnel
{
    public int PersonnelId { get; set; }

    public string? PersonnelFirstName { get; set; }

    public string? PersonnelLastName { get; set; }

    public string? PersonnelEmail { get; set; }

    public int? Hired { get; set; }

    public double? Wage { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
