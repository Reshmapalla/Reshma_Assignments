using System;
using System.Collections.Generic;

namespace HandsOnEFDBFirst.Entities;

public partial class Customer
{
    public string Customerid { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }
}
