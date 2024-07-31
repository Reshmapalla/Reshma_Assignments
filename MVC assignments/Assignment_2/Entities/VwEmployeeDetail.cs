using System;
using System.Collections.Generic;

namespace HandsOnEFDBFirst.Entities;

public partial class VwEmployeeDetail
{
    public string EmpName { get; set; } = null!;

    public int EmpId { get; set; }

    public string? Designation { get; set; }
}
