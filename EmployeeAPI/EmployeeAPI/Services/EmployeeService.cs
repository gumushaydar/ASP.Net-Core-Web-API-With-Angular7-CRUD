using EmployeeAPI.Domain.Models;
using EmployeeAPI.Domain.Repositories;
using EmployeeAPI.Domain.Services;
using EmployeeAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResponse> DeleteAsync(int id)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if(existingEmployee == null)
                return new EmployeeResponse("Employee Not Found");
            try
            {
                 _employeeRepository.Remove(existingEmployee);
                 await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
                
            }
            catch (Exception ex)
            {

                return new EmployeeResponse($"An error occurred when deleting the employee: {ex.Message}"); 
            }

        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<EmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.AddAsync(employee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(employee);
            }
            catch (Exception ex)
            {

                
                return new EmployeeResponse($"An error occurred when saving the employee: {ex.Message}");
            }
            
        }

        public async Task<EmployeeResponse> UpdateAsync(int id, Employee employee)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee Not Found");

            existingEmployee.EmployeeName = employee.EmployeeName;
            existingEmployee.EMPCode = employee.EMPCode;
            existingEmployee.Position = employee.Position;
            existingEmployee.Mobile = employee.Mobile;

            try
            {
                _employeeRepository.Update(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);


            }
            catch (Exception ex )
            {

                
                return new EmployeeResponse($"An error occurred when update the employee: {ex.Message}");
            }
        }
    }
}
