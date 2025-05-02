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
    public class CustomerService(IGenericRepository _repository) : ICustomerService
    {
        public Task<IEnumerable<Customers>> GetAllCustomersAsync()
        {
            return _repository.GetAllAsync<Customers>();
        }
    }
}
