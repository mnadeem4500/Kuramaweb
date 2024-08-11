using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class UserRegionController : PortalBaseController
    {
        private readonly UserRegionFuncion userRegionFuncion;
        public UserRegionController(UserRegionFuncion userRegionFuncion)
        {
            this.userRegionFuncion = userRegionFuncion;
            
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var urf = userRegionFuncion.GetAll();
            return Ok(urf);
        }
        [HttpGet("GetById/{regionId}")]
        public IActionResult Get(string region)
        {
            var urf = userRegionFuncion.GetById(region);
            return Ok(urf);
        }
        [HttpPost("Create")]
        public IActionResult Create(UserRegionDto regiodto)
        {
            var urf = userRegionFuncion.Create(regiodto);
            return Ok(regiodto);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserRegionDto regiondto)
        {
            var urf = userRegionFuncion.Update(regiondto);
                return Ok(regiondto);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(UserRegionDto regionDto)
        {
            var grp = userRegionFuncion.Remove(regionDto);
            return Ok(regionDto);
        }

    }

}
