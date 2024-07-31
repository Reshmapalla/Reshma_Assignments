using System;
using System.Collections.Generic;

namespace HandsOnEFDBFirst.Entities;

public partial class Department
{
    public string DeptCode { get; set; } = null!;

    public string DeptName { get; set; } = null!;

    public virtual ICollection<EmpDetail> EmpDetails { get; set; } = new List<EmpDetail>();
}
