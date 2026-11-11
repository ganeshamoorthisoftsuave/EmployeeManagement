using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeesController(IEmployeeService service)
    {
        _service = service;
    }
    [HttpPost]
    public IActionResult AddEmployee(EmployeeCreateDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Age = dto.Age,
            Salary = dto.Salary,
            Department = dto.Department
        };
        _service.AddEmployee(employee);

        return Ok("Employee added successfully");
    }

    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employees = _service.GetAllEmployees();
        var result = employees.Select(e => new EmployeeResponseDto
        {
            Id = e.Id,
            Name = e.Name,
            Age = e.Age,
            Salary = e.Salary,
            Department = e.Department
        }).ToList();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = _service.GetEmployeeById(id);

        if (employee == null)
            return NotFound("Employee not found");

        return Ok(employee);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, Employee employee)
    {
        var result = _service.UpdateEmployee(id, employee);

        if (!result)
            return NotFound("Employee not found");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var result = _service.DeleteEmployee(id);

        if (!result)
            return NotFound("Employee not found");

        return NoContent();
    }

    [HttpGet("average-salary")]
    public IActionResult GetAverageSalary()
    {
        return Ok(_service.CalculateAverageSalary());
    }

    [HttpGet("filter-by-salary")]
    public IActionResult FilterBySalary([FromQuery] double salary)
    {
        return Ok(_service.FilterBySalary(salary));
    }

    [HttpGet("names")]
    public IActionResult GetEmployeeNames()
    {
        return Ok(_service.GetEmployeeNames());
    }

    [HttpGet("sort-by-salary")]
    public IActionResult SortBySalary()
    {
        return Ok(_service.SortBySalary());
    }

    [HttpGet("sort-by-salary-descending")]
    public IActionResult SortBySalaryDescending()
    {
        return Ok(_service.SortBySalaryDescending());
    }

    [HttpGet("group-by-department")]
    public IActionResult GroupByDepartment()
    {
        return Ok(_service.GroupByDepartment());
    }

    [HttpGet("count")]
    public IActionResult GetEmployeeCount()
    {
        return Ok(_service.GetEmployeeCount());
    }

    [HttpGet("total-salary")]
    public IActionResult GetTotalSalary()
    {
        return Ok(_service.GetTotalSalary());
    }

    [HttpGet("search")]
    public IActionResult SearchByName([FromQuery] string name)
    {
        return Ok(_service.SearchByName(name));
    }
}

