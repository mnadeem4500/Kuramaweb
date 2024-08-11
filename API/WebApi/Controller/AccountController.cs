using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Controller;
using ExtremeClassified.WebApi.Dtos.Account;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : PortalBaseController

    {
        private readonly UserFunctions userfunction;
        public AccountController(UserFunctions userFunctions)
        {
            this.userfunction = userFunctions;
        }

        [HttpGet("TestCode")]
        public IActionResult TestCode()
        {
            return Ok("Application is running");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {

            return Ok(new { Message = "Working... one 2 5 ==>" + dto.Password });

        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var acc = userfunction.CreateUser(dto);

            return Ok(acc);

            // return Ok(new { Message = "Registration successful for email: " + dto.Email });
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //  return Ok("<h4>Define Data </h4>");
            var grp = userfunction.GetAll();
            return Ok(grp);
        }

    }
}
