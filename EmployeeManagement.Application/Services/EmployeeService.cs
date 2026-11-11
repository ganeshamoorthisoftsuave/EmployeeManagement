using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> employees = new List<Employee>();

        public async Task<Employee?> GetEmployeeAsync( int id, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);

            return GetEmployeeById(id);
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee? GetEmployeeById(int id)
        {
            return employees.Find(e => e.Id == id);
        }

        public double CalculateAverageSalary()
        {
            if (employees.Count == 0)
                return 0;

            return employees.Average(e => e.Salary);
        }

        public List<Employee> FilterBySalary(double salary)
        {
            return employees
                .Where(e => e.Salary > salary)
                .ToList();
        }

        public List<string> GetEmployeeNames()
        {
            return employees
                .Select(e => e.Name)
                .ToList();
        }

        public List<Employee> SortBySalary()
        {
            return employees
                .OrderBy(e => e.Salary)
                .ToList();
        }

        public List<Employee> SortBySalaryDescending()
        {
            return employees
                .OrderByDescending(e => e.Salary)
                .ToList();
        }

        public IEnumerable<IGrouping<int, Employee>> GroupByDepartment()
        {
            return employees.GroupBy(e => e.DepartmentId);
        }

        public int GetEmployeeCount()
        {
            return employees.Count();
        }

        public double GetTotalSalary()
        {
            return employees.Sum(e => e.Salary);
        }

        public List<Employee> SearchByName(string name)
        {
            return employees
                .Where(e => e.Name.Contains(
                    name,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
