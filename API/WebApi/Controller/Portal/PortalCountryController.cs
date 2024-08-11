using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Dtos.Portal;
using ExtremeClassified.WebApi.Functions.Listing;
using ExtremeClassified.WebApi.Functions.Portal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Portal
{
    [Route("[controller]")]
    
    public class PortalCountryController : PortalBaseController
    {
        private readonly PortalFunction portalFunction;
        public PortalCountryController(PortalFunction portalfunction)
        {
            this.portalFunction = portalfunction;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var portal = portalFunction.GetAllCountryWithDetails;
            return Ok(portal);
        }
        
        [HttpPost("Create")]
        public IActionResult Create(PortalCountryDto portalCountryDto)
        {
            var portal = portalFunction.CreatePortal(portalCountryDto);
            return Ok(portal);
        }
        [HttpPut("Update")]
        public IActionResult Update(PortalCountryDto portalCountryDto)
        {
            var portal = portalFunction.UpdatePortal(portalCountryDto);
            return Ok(portal);
        }

        [HttpPost("Createadministrativ")]
        public IActionResult Create(CountryAdministrativeDivisionDto countryAdministrativeDivisionDto)
        {
            var portal = portalFunction.CreatCountryAdministrativeDivision(countryAdministrativeDivisionDto);
            return Ok(portal);

        }
        [HttpPost("Updateadministrativ")]
        public IActionResult Update(CountryAdministrativeDivisionDto countryAdministrativeDivisionDto)
        {
            var portal = portalFunction.UpdateCountryAdministrativeDivision(countryAdministrativeDivisionDto);
            return Ok(portal);

        }

        //[HttpDelete("Delete")]
        ////public IActionResult Delete(PortalCountryDto portalCountryDto)
        ////{
        ////    var listing = portalFunction.re(portalCountryDto);
        ////    return Ok(listing);
        ////}

    }
}
