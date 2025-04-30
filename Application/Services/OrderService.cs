using Application.dto.Order;
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
    public class OrderService(IGenericRepository _repository) : IOrderService
    {
        public async Task<int> CreateOrderAsync(CreateOrderRequest request)
        {
            var order = new Orders
            {
                CustomerID = request.CustomerId,
                EmployeeID = request.EmployeeId,
                OrderDate = request.OrderDate,
                ShipAddress = request.ShipAddress,
            };

            await _repository.AddAsync(order);
            await _repository.SaveChangesAsync();

            return order.OrderID;
        }
    }
}
