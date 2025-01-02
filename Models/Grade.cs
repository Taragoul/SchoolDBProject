using System;
using System.Collections.Generic;

namespace SchoolDBProject.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int TeacherId { get; set; }

    public string Grade1 { get; set; } = null!;

    public DateTime? GradeDate { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Personnel Teacher { get; set; } = null!;
}
