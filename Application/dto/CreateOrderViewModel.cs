using Application.dto.Order;
using Application.dto.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.dto
{
    public class CreateOrderViewModel
    {
        public CreateOrderRequest? Order { get; set; }
        public CreateOrderDetailRequest? OrderDetails { get; set; }
    }
}
