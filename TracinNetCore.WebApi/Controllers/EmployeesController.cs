using Microsoft.AspNetCore.Mvc;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Entities.Concrete;

namespace TracinNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // Get All Employees
        [HttpGet("getall")]
        public IActionResult GetList()
        {
           var result = employeeService.GetList();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Employees By Id
        [HttpGet("getbyid")]
        public IActionResult Get(int employeeId)
        {
            var result = employeeService.GetById(employeeId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Add New Employee
        [HttpPost("add")]
        public IActionResult Add(Employee employee)
        {
            var result = employeeService.Add(employee);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        // Update Employee
        [HttpPost("update")]
        public IActionResult Update(Employee employee)
        {
            var result = employeeService.Update(employee);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        // Delete Device
        [HttpPost("delete")]
        public IActionResult Delete(Employee employee)
        {
            var result = employeeService.Delete(employee);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
