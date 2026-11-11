using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> departments = new List<Department>();

        public void AddDepartment(Department department)
        {
            departments.Add(department);
        }

        public List<Department> GetAllDepartments()
        {
            return departments;
        }
    }
}
