using System;
using System.Collections.Generic;

namespace SchoolDBProject.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentFirstName { get; set; }

    public string? StudentLastName { get; set; }

    public string? StudentEmail { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
