using EmployeeAPI.Domain.Models;
using EmployeeAPI.Domain.Repositories;
using EmployeeAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository , IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
        }

        public async Task<Employee> FindByIdAsync(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public void Remove(Employee existingEmployee)
        {
            _context.Employee.Remove(existingEmployee);
        }

        public void Update(Employee existingEmployee)
        {
            _context.Employee.Update(existingEmployee);
        }
    }
}
