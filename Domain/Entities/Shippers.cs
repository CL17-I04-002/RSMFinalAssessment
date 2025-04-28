using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Shippers
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;

        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
