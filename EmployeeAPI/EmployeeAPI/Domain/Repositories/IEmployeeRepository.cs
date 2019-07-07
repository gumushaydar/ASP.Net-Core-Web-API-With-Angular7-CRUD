using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.Domain.Models;

namespace EmployeeAPI.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task AddAsync(Employee employee);
        Task<Employee> FindByIdAsync(int id);
        void Update(Employee existingEmployee);
        void Remove(Employee existingEmployee);
    }
}
