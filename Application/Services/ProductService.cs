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
    public class ProductService(IGenericRepository _repository) : IProductService
    {
        public Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return _repository.GetAllAsync<Products>();
        }

        public Task<Products> GetProductByIdAsync(int id)
        {
            return _repository.GetByIdAsync<Products>(id);
        }
    }
}
