using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        private readonly UserTokenFunction userTokenFunction;
        public UserTokenController(UserTokenFunction userToken)
        {
            this.userTokenFunction=userToken;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var entity = userTokenFunction.GetAll();
            return Ok(entity);
        }
        [HttpGet("GetById/{tokenid}")]
        public IActionResult Get(int tokenid)
        {
            var entity = userTokenFunction.GetById(tokenid);
            return Ok(entity);
        }
        [HttpPost("Create")]
        public IActionResult Create(UserTokenDto userTokenDto) 
        {
            var entity = userTokenFunction.Create(userTokenDto);
            return Ok(entity);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserTokenDto userTokenDto)
        {
            var entity = userTokenFunction.Update(userTokenDto);
            return Ok(entity);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(UserTokenDto userTokenDto)
        {
            var entity = userTokenFunction.Remove(userTokenDto);
                return Ok(entity);
        }
    }
}
