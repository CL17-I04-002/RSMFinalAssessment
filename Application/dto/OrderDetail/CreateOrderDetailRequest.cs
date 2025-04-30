using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.dto.OrderDetail
{
    public class CreateOrderDetailRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
    }
}
