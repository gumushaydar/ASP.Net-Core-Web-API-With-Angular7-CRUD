using EmployeeAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Services.Communication
{
    public class EmployeeResponse : BaseResponse
    {
        public Employee Employee { get; set; }

        public EmployeeResponse(bool success, string message, Employee employee) : base(success, message)
        {
            Employee = employee;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="employee">Saved product.</param>
        /// <returns>Response.</returns>
        public EmployeeResponse(Employee employee) : this(true, string.Empty, employee)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EmployeeResponse(string message) : this(false, message, null)
        { }
    }
}
