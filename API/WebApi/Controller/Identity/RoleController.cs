using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : PortalBaseController
    {
        private readonly RoleFunction roleFunction;
        public RoleController(RoleFunction roleFunction)
        {
            this.roleFunction = roleFunction;

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var role = roleFunction.GetAll();
            return Ok(role);

        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var role = roleFunction.GetById(id);
            return Ok(role);
        }
        [HttpPost("Create")]
        public IActionResult Create(RoleDto roles)
        {
            var role = roleFunction.Create(roles);
            return Ok(new { Name = role, Des = roles.RoleDescription });
        }
        [HttpPost("Update")]
        public IActionResult Update(RoleDto roles)
        {
            var role = roleFunction.Update(roles);
            return Ok(role);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(RoleDto roles)
        {
            var role = roleFunction.Remove(roles);
            return Ok(role);
        }



    }
}
