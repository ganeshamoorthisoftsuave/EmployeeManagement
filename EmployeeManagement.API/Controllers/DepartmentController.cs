using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody] Department department)
        {
            _service.AddDepartment(department);

            return Ok("Department added successfully");
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            return Ok(_service.GetAllDepartments());
        }
    }
}
