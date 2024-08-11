using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class UserAddressController : PortalBaseController
    {
        private readonly UserAddressFunction useraddressfunction;
        public UserAddressController(UserAddressFunction addressfunction)
        {
            this.useraddressfunction=addressfunction;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var uaf = useraddressfunction.GetAll();
            return Ok();
        }
        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var uaf = useraddressfunction.GetById(id);
                return Ok(uaf);
        }
        [HttpPost("Create")]
        public IActionResult Create(UserAddressDto address)
        {
            var uaf = useraddressfunction.Create(address);
            return Ok(uaf);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserAddressDto address)
        {
            var uaf = useraddressfunction.Update(address);
            return Ok(uaf);
        }
        [HttpDelete("Remove")]
        public IActionResult Remove(UserAddressDto address)
        {
            var uaf = useraddressfunction.Remove(address);
            return Ok(uaf);
        }
    }
}
