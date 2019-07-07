using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using AutoMapper;
using EmployeeAPI.Domain.Models;
using EmployeeAPI.Domain.Services;
using EmployeeAPI.Extensions;
using EmployeeAPI.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<EmployeeResource>> GetListAsync()
        {
            var employees = await _employeeService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees);

            return resource;
        }



        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.SaveAsync(employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(employee);

            return Ok(employeeResource);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.UpdateAsync(id, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);

            return Ok(employeeResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessage());

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);

            return Ok(employeeResource);
        }



    }
}