using System;
using System.Collections.Generic;

namespace HandsOnEFDBFirst.Entities;

public partial class VwEmpDept
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string? Dept1Code { get; set; }

    public string DeptName { get; set; } = null!;
}
