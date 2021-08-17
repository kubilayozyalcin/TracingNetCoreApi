using Microsoft.AspNetCore.Mvc;
using TracingNetCore.Business.Abstractions;

namespace TracinNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDevicesController : ControllerBase
    {
        private IEmployeeDeviceService employeeDeviceService;

        public EmployeeDevicesController(IEmployeeDeviceService employeeDeviceService)
        {
            this.employeeDeviceService = employeeDeviceService;
        }

        // Get All Employee Devices
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = employeeDeviceService.GetList();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Employee Devices By Id
        [HttpGet("getbyid")]
        public IActionResult Get(int employeeDeviceId)
        {
            var result = employeeDeviceService.GetById(employeeDeviceId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Employee Devices By Employee Id
        [HttpGet("getbyemployeeid")]
        public IActionResult GetByEmployeeDevice(int employeeId)
        {
            var result = employeeDeviceService.GetByEmployeeDevice(employeeId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Employee Devices By Device Id
        [HttpGet("getbydeviceid")]
        public IActionResult GetByDevice(int deviceId)
        {
            var result = employeeDeviceService.GetByDevice(deviceId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        //// Add New Employee Device
        //[HttpPost("add")]
        //public IActionResult Add(EmployeeDevice employeeDevice)
        //{
        //    var result = employeeDeviceService.Add(employeeDevice);
        //    if (result.Success)
        //        return Ok(result.Message);
        //    return BadRequest(result.Message);
        //}


        //// Delete Employee Device
        //[HttpPost("delete")]
        //public IActionResult Delete(EmployeeDevice employeeDevice)
        //{
        //    var result = employeeDeviceService.Delete(employeeDevice);
        //    if (result.Success)
        //        return Ok(result.Message);
        //    return BadRequest(result.Message);
        //}
    }
}
