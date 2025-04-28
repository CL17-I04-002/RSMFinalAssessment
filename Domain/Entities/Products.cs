using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Products
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; } = string.Empty;
        public int? SupplierID { get; set; } = 0;
        public int? CategoryID { get; set; } = 0;
        public string? QuantityPerUnit { get; set; } = string.Empty;
        public decimal? UnitPrice { get; set; } = 0M;
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
