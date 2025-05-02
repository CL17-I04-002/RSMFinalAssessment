using Application.dto.OrderDetail;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderDetailService(IGenericRepository _repository) : IOrderDetailService
    {
        public async Task CreateOrderAsync(CreateOrderDetailRequest request)
        {
            var product = await _repository.GetByIdAsync<Products>(request.ProductId);

            var detail = new OrderDetails
            {
                OrderID = request.OrderId,
                ProductID = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = product.UnitPrice ?? 0M,
                Discount = 0
            };

            await _repository.AddAsync(detail);
            await _repository.SaveChangesAsync();
        }
    }
}
