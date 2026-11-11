using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);

        List<Employee> GetAllEmployees();

        Employee? GetEmployeeById(int id);

        bool UpdateEmployee(int id, Employee employee);

        bool DeleteEmployee(int id);

        double CalculateAverageSalary();

        List<Employee> FilterBySalary(double salary);

        List<string> GetEmployeeNames();

        List<Employee> SortBySalary();

        List<Employee> SortBySalaryDescending();

        IEnumerable<IGrouping<int, Employee>> GroupByDepartment();

        int GetEmployeeCount();

        double GetTotalSalary();

        List<Employee> SearchByName(string name);
    }
}
