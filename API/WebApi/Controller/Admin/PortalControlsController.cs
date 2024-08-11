using ExtremeClassified.Core;
using ExtremeClassified.WebApi.Dtos;
using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Dtos.Portal;
using ExtremeClassified.WebApi.Functions.Listing;
using ExtremeClassified.WebApi.Functions.Portal;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Admin
{
    [Route("[controller]")]
    [ApiController]
    //Screen Controls
    public class PortalControlsController : PortalBaseController
    {
        // private readonly ScreenControlFunction screenControlFunction;
        //public PortalControlsController(ScreenControlFunction screencontrolfunction)
        //{
        //    screenControlFunction = screencontrolfunction;
        //}
        private readonly ScreenControlFunction _screenControlfunction;
        public PortalControlsController(ScreenControlFunction screenControlfunction)
        {
            _screenControlfunction = screenControlfunction;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var screen = _screenControlfunction.GetAll();
            return Ok(screen);
        }
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var screen = _screenControlfunction.GetById(id);

            return Ok(screen);
        }
        [HttpPost("Create")]
        public IActionResult Create(ScreenControlDto screenControleDto)
        {
            var screen = _screenControlfunction.Create(screenControleDto);
            if (!string.IsNullOrEmpty(screen))
                return Ok(new ApiResponse { Success = false, Message = screen });

            return Ok(new ApiResponse { Success = true });

           
        }
        [HttpPost("Update")]
        public IActionResult Update(ScreenControlDto screenControleDto)
        {
            var screen = _screenControlfunction.Update(screenControleDto);

            return Ok(new ApiResponse { Success = true });
        }
        [HttpPost("Delete")]
        public IActionResult Delete(ScreenControlDto screenControleDto)
        {
            _screenControlfunction.Remove(screenControleDto);
            return Ok(new ApiResponse { Success = true });
        }
    }
}

