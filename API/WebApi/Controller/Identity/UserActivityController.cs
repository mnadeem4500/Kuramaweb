using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class UserActivityController : PortalBaseController
    {
        private readonly UserActivityFunction useractivityfunction;
        public UserActivityController(UserActivityFunction userActivityFunction)
        {
            this.useractivityfunction = userActivityFunction;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var uaf = useractivityfunction.GetAll();
            return Ok(uaf);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetByID(string id)
        {
            var uaf = useractivityfunction.GetById(id);
            return Ok(uaf);
        }
        [HttpPost("Create")]
        public IActionResult Create(UserActivityDto activity)
        {
            var uaf = useractivityfunction.Create(activity);
            return Ok(uaf);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserActivityDto activity)
        {
            var uaf = useractivityfunction.Update(activity);
            return Ok(uaf);
        }
    }
}
