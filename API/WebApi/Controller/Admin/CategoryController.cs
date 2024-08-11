using ExtremeClassified.WebApi.Dtos;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Functions.Identity;
using ExtremeClassified.WebApi.Functions.Listing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ExtremeClassified.WebApi.Controller.Admin
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryFunction categoryFunction;
        private readonly CategoryPropertyFunction _categoryPropertyFunction;

        public CategoryController(CategoryFunction categoryfunction, CategoryPropertyFunction categorypropertyfunction, IWebHostEnvironment _environment)
        {
            categoryFunction = categoryfunction;
            _categoryPropertyFunction = categorypropertyfunction;


        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var category = categoryFunction.GetAll();
            return Ok(category);
        }
        [HttpGet("GetRootCatgories")]
        public IActionResult GetRootCatgories()
        {

            var category = categoryFunction.GetRootCatgories();
            return Ok(category);
        }


        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var category = categoryFunction.GetById(id);

            return Ok(category);
        }
        [HttpPost("Create")]
        public IActionResult Create(CategoryDto categoryDto)
        {
            var result = categoryFunction.Create(categoryDto);

            if (string.IsNullOrEmpty(result))
                return Ok(new ApiResponse { Success = false, Message = result });

            return Ok(new ApiResponse { Success = true });
        }
        //[HttpPut("Update")]
        //public IActionResult Update(CategoryDto categoryDto)

        //{
        //    var category = categoryFunction.Update(categoryDto);
        //    return Ok(new ApiResponse { Success = true });
        //}
        [HttpPost("Delete")]
        public IActionResult Delete(CategoryDto categoryDto)
        {
            categoryFunction.Remove(categoryDto);
            return Ok(new ApiResponse { Success = true });
        }

        #region Category Properties
        [HttpPost("PropertyCreate")]
        public IActionResult Create(CategoryPropertyDto propertyDto)
        {
            var result = _categoryPropertyFunction.Create(propertyDto);
            if (!string.IsNullOrEmpty(result))
                return Ok(new ApiResponse { Success = false, Message = result });

            return Ok(new ApiResponse { Success = true });

        }
        [HttpPost("PropertyUpdate")]
        public IActionResult Update(CategoryPropertyDto propertyDto)
        {
            var result = _categoryPropertyFunction.Update(propertyDto);
            return Ok(new ApiResponse { Success = true });
        }
        [HttpGet("PropertyGetAll")]
        public IActionResult GetAllProperty()
        {
            var result = _categoryPropertyFunction.GetAll();
            return Ok(result);
        }
        [HttpPost("PropertyDelete")]
        public IActionResult Delete(CategoryPropertyDto propertyDto)
        {
            _categoryPropertyFunction.Remove(propertyDto);
            return Ok(new ApiResponse { Success = true });
        }

        #endregion
    }

}

