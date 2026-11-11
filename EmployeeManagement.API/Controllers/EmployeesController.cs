using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Models;
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
    public IActionResult AddEmployee(Employee employee)
    {
        _service.AddEmployee(employee);

        return Ok("Employee added successfully");
    }

    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        return Ok(_service.GetAllEmployees());
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = _service.GetEmployeeById(id);

        if (employee == null)
            return NotFound("Employee not found");

        return Ok(employee);
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

