using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Dtos;
using ExtremeClassified.WebApi.Functions.Listing;
using ExtremeClassified.WebApi.Functions.Portal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtremeClassified.WebApi.Dtos.Portal;
using ExtremeClassified.Core;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore.Storage;

namespace ExtremeClassified.WebApi.Controller.Admin
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogueController : PortalBaseController
    {

        private readonly CatalogueFunctions catalogueFunctions;
        public CatalogueController(CatalogueFunctions cataloguefunctions)
        {
            catalogueFunctions = cataloguefunctions;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAllMasterWithDetailsAll()
        {

            var catalogue = catalogueFunctions.GetAllMasterWithDetailsAll();
            return Ok(catalogue);
        }
        [HttpPost("Create")]
        public IActionResult Create(CatalogueMasterDto catalogueDto)
        {
            var result = catalogueFunctions.CreateMaster(catalogueDto);


            if (result == OperationResponse.Error.ToString())
            {
                return Ok(new ApiResponse { Success = false, Message = "There is problem while creating catalogue." });
            }

            foreach (var item in catalogueDto.CatalogueDetails)
            {
                item.MasterId = result;
            }

            var catalogueDetailresult = catalogueFunctions.CreateDetail(catalogueDto.CatalogueDetails.ToArray());


            if (catalogueDetailresult == OperationResponse.Error.ToString())
            {
                return Ok(new ApiResponse { Success = false, Message = "There is problem while creating catalogue details." });
            }

            return Ok(new ApiResponse { Success = true });
        }
        [HttpPost("Update")]
        public IActionResult Update(CatalogueMasterDto catalogueDto)
        {
            var result = catalogueFunctions.UpdateMaster(catalogueDto);

            if (result == OperationResponse.Error.ToString())
            {
                return Ok(new ApiResponse
                { Success = false, Message = "There is problem while updating catalogue." });
            }
            var newDetails = catalogueDto.CatalogueDetails.Where(x => !x.MasterId.Equals(catalogueDto.MasterId));
            var updateDetails = catalogueDto.CatalogueDetails.Where(x => x.MasterId.Equals(catalogueDto.MasterId));

            foreach (var item in newDetails)
            {
                item.MasterId = result;
            }
            if (newDetails.Count() > 0)
                result = catalogueFunctions.CreateDetail(newDetails.ToArray());

            if (result == OperationResponse.Error.ToString())
            {
                return Ok(new ApiResponse { Success = false, Message = "There is problem while creating new catalogue details." });
            }

            result = catalogueFunctions.UpdateDetail(updateDetails.ToArray());

            if (result == OperationResponse.Error.ToString())
            {
                return Ok(new ApiResponse { Success = false, Message = "There is problem while updating catalogue details." });
            }

            return Ok(new ApiResponse { Success = true });
        }

        [HttpPost("Delete/{masterId}")]
        public IActionResult Delete(string masterId)
        {
            catalogueFunctions.Remove(masterId);
            return Ok(new ApiResponse { Success = true });
        }

    }


}
