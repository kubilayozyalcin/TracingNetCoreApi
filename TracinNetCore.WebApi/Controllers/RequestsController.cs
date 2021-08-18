using Microsoft.AspNetCore.Mvc;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Entities.Concrete;

namespace TracinNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private IRequestService requestService;

        public RequestsController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        // Get All Request
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = requestService.GetList();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Request By Id
        [HttpGet("getbyid")]
        public IActionResult Get(int requestId)
        {
            var result = requestService.GetById(requestId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Request By Employee Id
        [HttpGet("getbyemployee")]
        public IActionResult GetByEmployee(int employeeId)
        {
            var result = requestService.GetByEmployeeId(employeeId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Request By Device Id
        [HttpGet("getbydevice")]
        public IActionResult GetByDevice(int deviceId)
        {
            var result = requestService.GetByDeviceId(deviceId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Add New Request
        [HttpPost("add")]
        public IActionResult Add(Request request)
        {
            var result = requestService.Add(request);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        // Update Request
        [HttpPost("update")]
        public IActionResult Update(Request request)
        {
            var result = requestService.Update(request);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

    }
}
