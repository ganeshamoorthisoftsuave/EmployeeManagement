using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Domain.DTO
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int Age { get; set; }

        public double Salary { get; set; }

        public Department? Department { get; set; }
    }
}
