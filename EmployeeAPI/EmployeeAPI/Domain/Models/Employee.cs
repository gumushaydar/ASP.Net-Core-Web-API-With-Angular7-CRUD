using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string EmployeeName { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string EMPCode { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Position { get; set; }
        [Required]
        [Column(TypeName = "varchar(11)")]
        public string Mobile { get; set; }

    }
}
