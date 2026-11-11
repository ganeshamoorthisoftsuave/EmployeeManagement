using Xunit;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Services;

namespace EmployeeManagement.Test;

public class EmployeeServiceTests
{
    [Fact]
    public void AddEmployee_ShouldAddEmployee()
    {
        // Arrange
        var service = new EmployeeService();

        var employee = new Employee
        {
            Id = 1,
            Name = "Ganesh",
            Salary = 30000
        };

        // Act
        service.AddEmployee(employee);

        // Assert
        Assert.Single(service.GetAllEmployees());
    }

    [Fact]
    public void GetEmployeeById_ShouldReturnEmployee()
    {
        var service = new EmployeeService();

        service.AddEmployee(new Employee
        {
            Id = 1,
            Name = "Ganesh"
        });

        var result = service.GetEmployeeById(1);

        Assert.NotNull(result);
        Assert.Equal("Ganesh", result.Name);
    }

    [Fact]
    public void GetEmployeeById_ShouldReturnNull()
    {
        var service = new EmployeeService();

        var result = service.GetEmployeeById(100);

        Assert.Null(result);
    }

    [Fact]
    public void GetAllEmployees_ShouldReturnAllEmployees()
    {
        var service = new EmployeeService();

        service.AddEmployee(new Employee { Id = 1, Name = "Ganesh" });
        service.AddEmployee(new Employee { Id = 2, Name = "Arun" });

        var result = service.GetAllEmployees();

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void CalculateAverageSalary_ShouldReturnAverage()
    {
        var service = new EmployeeService();

        service.AddEmployee(new Employee { Id = 1, Salary = 20000 });
        service.AddEmployee(new Employee { Id = 2, Salary = 30000 });

        var result = service.CalculateAverageSalary();

        Assert.Equal(25000, result);
    }
    [Fact]
    public async Task GetEmployeeAsync_ShouldReturnEmployee()
    {
        var service = new EmployeeService();

        service.AddEmployee(new Employee
        {
            Id = 1,
            Name = "Ganesh"
        });

        var result = await service.GetEmployeeAsync(
            1,
            CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal("Ganesh", result.Name);
    }
    [Fact]
    public async Task GetEmployeeAsync_ShouldCancelOperation()
    {
        var service = new EmployeeService();

        using var cts = new CancellationTokenSource();

        cts.Cancel();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(
            () => service.GetEmployeeAsync(1, cts.Token));
    }
}