using System;
using System.Collections.Generic;

namespace HandsOnEFDBFirst.Entities;

public partial class EmpDetail
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string? Dept1Code { get; set; }

    public string? Designation { get; set; }

    public DateOnly? JoinDate { get; set; }

    public int? EmpAge { get; set; }

    public int? Manager { get; set; }

    public virtual Department? Dept1CodeNavigation { get; set; }
}
