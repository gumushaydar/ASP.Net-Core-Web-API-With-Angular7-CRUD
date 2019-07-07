using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Resources
{
    public class SaveEmployeeResource
    {

        [Required]
        [MaxLength(30)]
        public string EmployeeName { get; set; }

        [Required]
        [MaxLength(5)]
        public string EMPCode { get; set; }

        [Required]
        [MaxLength(30)]
        public string Position { get; set; }

        [Required]
        [MaxLength(30)]
        public string Mobile { get; set; }
    }
}
