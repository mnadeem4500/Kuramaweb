using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class UserAccessController : PortalBaseController
    {
        private readonly UserAccessFunction useraccessfunction;
        public UserAccessController(UserAccessFunction userAccessFunction )
        {
            this.useraccessfunction = userAccessFunction;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var uaf = useraccessfunction.GetAll();
            return Ok(uaf);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var uaf = useraccessfunction.GetById(id);
             return Ok(uaf);
        }
        [HttpPost("Create")]
        public IActionResult Create(UserAccessDto uafunction) 
        {
            var uaf = useraccessfunction.Create(uafunction);
            return Ok(uaf);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserAccessDto uafunciton)
        {
            var uaf = useraccessfunction.Update(uafunciton);
            return Ok(uaf);
        }
        [HttpDelete("Delet")]
        public IActionResult Remove(UserAccessDto uafunction)
        {
            var uaf = useraccessfunction.Remove(uafunction);
            return Ok(uaf);
        }




    }
}
