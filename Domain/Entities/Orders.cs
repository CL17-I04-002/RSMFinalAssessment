using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Orders
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; } = string.Empty;
        public int? EmployeeID { get; set; } = 0;
        public DateTime? OrderDate { get; set; } = new DateTime();
        public DateTime? RequiredDate { get; set; } = new DateTime();
        public DateTime? ShippedDate { get; set; } = new DateTime();
        public int? ShipVia { get; set; } = 0;
        public decimal? Freight { get; set; } = 0M;
        public string? ShipName { get; set; } = string.Empty;
        public string? ShipAddress { get; set; } = string.Empty;
        public string? ShipCity { get; set; } = string.Empty;
        public string? ShipRegion { get; set; } = string.Empty;
        public string? ShipPostalCode { get; set; } = string.Empty;
        public string? ShipCountry { get; set; } = string.Empty;

        public virtual Customers? Customer { get; set; }
        public virtual Employees? Employee { get; set; }

        public virtual Shippers? Shipper { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }

}
