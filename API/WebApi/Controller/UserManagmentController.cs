using ExtremeClassified.WebApi.Dtos.Account;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagmentController : ControllerBase
    {
        [HttpGet("Testing")]
        public IActionResult TestCode()
        {
            return Ok("Application is running");
        }
        [HttpGet("Role")]
        public IActionResult Role(RoleDto dto)
        {
            return Ok(dto.RoleId);

        }
        [HttpGet("UserAccess")]
        public IActionResult UserAccess(UserAccessDto dto)
        {
            return Ok();
        }
        [HttpGet("UserActivity")]
        public IActionResult UserActivity(UserAccessDto dto)
        {
            return Ok();
        }

       /* [HttpGet("UserAddress")]
        public IActionResult UserAddress(UserAddressDto dto)
        {
            return Ok();
        }*/


    }
}
