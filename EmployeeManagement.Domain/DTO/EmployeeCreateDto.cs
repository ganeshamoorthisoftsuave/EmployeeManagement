using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Domain.DTO
{
    public class EmployeeCreateDto
    {
        [Required]
        public string Name { get; set; } = "";

        [Range(18, 60)]
        public int Age { get; set; }

        [Range(1, 1000000)]
        public double Salary { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
