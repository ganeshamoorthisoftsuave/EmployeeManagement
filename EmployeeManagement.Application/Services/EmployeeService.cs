using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(ILogger<EmployeeService>? logger = null)
        {
            _logger = logger ?? Microsoft.Extensions.Logging.Abstractions.NullLogger<EmployeeService>.Instance;
        }
        private List<Employee> employees = new List<Employee>();

        public async Task<Employee?> GetEmployeeAsync( int id, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);

            return GetEmployeeById(id);
        }

        public void AddEmployee(Employee employee)
        {
            _logger.LogInformation( "Adding employee: {EmployeeName}", employee.Name);
            employees.Add(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            _logger.LogInformation("Retrieving all employees. Total count: {EmployeeCount}", employees.Count);
            return employees;
        }

        public Employee? GetEmployeeById(int id)
        {
            _logger.LogInformation("Retrieving employee with ID: {EmployeeId}", id);
            return employees.Find(e => e.Id == id);
        }

        public double CalculateAverageSalary()
        {
            _logger.LogInformation("Calculating average salary for {EmployeeCount} employees", employees.Count);
            if (employees.Count == 0)
                return 0;

            return employees.Average(e => e.Salary);
        }

        public List<Employee> FilterBySalary(double salary)
        {
            _logger.LogInformation("Filtering employees with salary greater than {Salary}", salary);
            return employees
                .Where(e => e.Salary > salary)
                .ToList();
        }

        public List<string> GetEmployeeNames()
        {
            _logger.LogInformation("Retrieving names of all employees. Total count: {EmployeeCount}", employees.Count);
            return employees
                .Select(e => e.Name)
                .ToList();
        }

        public List<Employee> SortBySalary()
        {
            _logger.LogInformation("Sorting employees by salary in ascending order");
            return employees
                .OrderBy(e => e.Salary)
                .ToList();
        }

        public List<Employee> SortBySalaryDescending()
        {
            _logger.LogInformation("Sorting employees by salary in descending order");
            return employees
                .OrderByDescending(e => e.Salary)
                .ToList();
        }

        public IEnumerable<IGrouping<int, Employee>> GroupByDepartment()
        {
            _logger.LogInformation("Grouping employees by department. Total count: {EmployeeCount}", employees.Count);
            return employees.GroupBy(e => e.DepartmentId);
        }

        public int GetEmployeeCount()
        {
            _logger.LogInformation("Retrieving employee count. Total count: {EmployeeCount}", employees.Count);
            return employees.Count();
        }

        public double GetTotalSalary()
        {
            _logger.LogInformation("Calculating total salary for {EmployeeCount} employees", employees.Count);
            return employees.Sum(e => e.Salary);
        }

        public List<Employee> SearchByName(string name)
        {
            _logger.LogInformation("Searching for employees with name containing: {Name}", name);
            return employees
                .Where(e => e.Name.Contains(
                    name,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool UpdateEmployee(int id, Employee employee)
        {
            _logger.LogInformation("Updating employee with ID: {EmployeeId}", id);
            var existingEmployee = GetEmployeeById(id);

            if (existingEmployee == null)
                return false;

            existingEmployee.Name = employee.Name;
            existingEmployee.Age = employee.Age;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.DepartmentId = employee.DepartmentId;

            return true;
        }

        public bool DeleteEmployee(int id)
        {
            _logger.LogInformation("Deleting employee with ID: {EmployeeId}", id);
            var employee = GetEmployeeById(id);

            if (employee == null)
                return false;

            employees.Remove(employee);

            return true;
        }
    }
}
