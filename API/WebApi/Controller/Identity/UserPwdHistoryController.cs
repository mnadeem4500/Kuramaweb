using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class UserPwdHistoryController : PortalBaseController
    {
        private readonly UserPwdHistoryFunction pwdHistoryFunction;
        public UserPwdHistoryController(UserPwdHistoryFunction userPwdHistoryFunction)
        {
            this.pwdHistoryFunction = userPwdHistoryFunction;
            
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var upf = pwdHistoryFunction.GetAll();
            return Ok(upf);
        }
        [HttpGet("GetById/{pwdid}")]
        public IActionResult Get(string id)
        {
            var upf = pwdHistoryFunction.GetById(id);
            return Ok(upf);
        }
        [HttpPost("Create")]
        public IActionResult Create(UserPwdHistoryDto pwddto)
        {
            var upf = pwdHistoryFunction.Create(pwddto);
            return Ok(upf);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserPwdHistoryDto pwddto)
        {
            var upf = pwdHistoryFunction.Update(pwddto);
            return Ok(upf);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(UserPwdHistoryDto pwddto)
        {
            var upf = pwdHistoryFunction.Remove(pwddto);
            return Ok(upf);
        }

    }
}
