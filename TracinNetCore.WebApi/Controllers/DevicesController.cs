using Microsoft.AspNetCore.Mvc;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Entities.Concrete;

namespace TracinNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private IDeviceService deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        // Get All Devices
        [HttpGet("getall")]
        public IActionResult GetList()
        {
           var result = deviceService.GetList();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Device By Id
        [HttpGet("getbyid")]
        public IActionResult Get(int deviceId)
        {
            var result = deviceService.GetById(deviceId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Device By Region Id
        [HttpGet("getbyregion")]
        public IActionResult GetByRegion(int regionId)
        {
            var result = deviceService.GetByRegionId(regionId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Get Device By Type Id
        [HttpGet("getbydevicetype")]
        public IActionResult GetByType(int typeId)
        {
            var result = deviceService.GetByTypeId(typeId);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        // Add New Device
        [HttpPost("add")]
        public IActionResult Add(Device device)
        {
            var result = deviceService.Add(device);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        // Update Device
        [HttpPost("update")]
        public IActionResult Update(Device device)
        {
            var result = deviceService.Update(device);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        // Delete Device
        [HttpPost("delete")]
        public IActionResult Delete(Device device)
        {
            var result = deviceService.Delete(device);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
