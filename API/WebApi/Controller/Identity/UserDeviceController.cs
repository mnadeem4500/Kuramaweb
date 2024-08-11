using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class UserDeviceController : PortalBaseController
    {
        private readonly UserDeviceFunction userDeviceFunction;
        public UserDeviceController(UserDeviceFunction devicefunction)
        {
            this.userDeviceFunction = devicefunction;
            
        }
        [HttpGet("GetAll")]
        public IActionResult Get() 
        {
            var udf = userDeviceFunction.GetAll();
            return Ok(udf);
        }
        [HttpGet("GetById/{id}")]
         public IActionResult Get(string id)
        {
            var udf = userDeviceFunction.GetById(id);
            return Ok(udf);
        }
        [HttpPost("Create")]
        public IActionResult Create(UserDeviceDto device)
        {
            var udf = userDeviceFunction.Create(device);
   
            return Ok(udf);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserDeviceDto device)
        {
            var udf = userDeviceFunction.Update(device);
            return Ok(udf);
        }
        [HttpDelete("Delet")]
        public IActionResult Remove(UserDeviceDto device)
        {
            var udf = userDeviceFunction.Remove(device);
            return Ok(udf);
        }


    }


}
