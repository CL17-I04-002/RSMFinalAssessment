﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customers
    {
        public string CustomerID { get; set; }
        public string? CompanyName { get; set; } = string.Empty;
        public string? ContactName { get; set; } = string.Empty;
        public string? ContactTitle { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Region { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Fax { get; set; } = string.Empty;

        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
