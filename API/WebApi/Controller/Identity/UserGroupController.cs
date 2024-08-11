using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : PortalBaseController
    {
        private readonly UserGroupFunction userGroupFunction;
        public UserGroupController( UserGroupFunction usergroup)
        {
            this.userGroupFunction = usergroup;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var ugf = userGroupFunction.GetAll();
            return Ok(ugf);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult Get(string id)
        {
            var ugf = userGroupFunction.GetById(id);
            return Ok(ugf);
        }
        [HttpPost("Create")]
        public IActionResult Create(UserGroupDto group)
        {
            var ugf = userGroupFunction.Create(group);
            return Ok(ugf);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserGroupDto group)
        {
            var ugf = userGroupFunction.Update(group);
            return Ok(ugf);
        }
        [HttpDelete("Delet")]
        public IActionResult Remove(UserGroupDto group)
        {
            var ugf = userGroupFunction.Remove(group);
            return Ok(ugf);
        }
    }
}
