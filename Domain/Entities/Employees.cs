using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string? LastName { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? Title { get; set; } = string.Empty;
        public string? TitleOfCourtesy { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; } = new DateTime();
        public DateTime? HireDate { get; set; } = new DateTime();
        public string? Address { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Region { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? HomePhone { get; set; } = string.Empty;
        public string? Extension { get; set; } = string.Empty;
        public byte[]? Photo { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public int? ReportsTo { get; set; } = 0;
        public string? PhotoPath { get; set; } = string.Empty;

        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
