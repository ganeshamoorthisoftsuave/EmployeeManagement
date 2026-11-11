using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IDepartmentService
    {
        void AddDepartment(Department department);

        List<Department> GetAllDepartments();
    }
}
