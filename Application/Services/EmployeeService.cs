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
    public class EmployeeService(IGenericRepository _repository) : IEmployeeService
    {
        public Task<IEnumerable<Employees>> GetAllEmployeesAsync()
        {
            return _repository.GetAllAsync<Employees>();
        }
    }
}
