using Application.dto.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderDetailService
    {
        Task CreateOrderAsync(CreateOrderDetailRequest request);
    }
}
