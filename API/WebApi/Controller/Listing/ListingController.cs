using ExtremeClassified.WebApi.Dtos;
using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Functions.Listing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Listing
{
    [Route("[controller]")]
    public class ListingController : PortalBaseController
    {
        private readonly ListingFunction listingFunction;
        private readonly IWebHostEnvironment webHost;
        public ListingController(ListingFunction listingfunction, IWebHostEnvironment webHost)
        {
            this.listingFunction = listingfunction;
            this.webHost = webHost;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var listing = listingFunction.GetAll();
            return Ok(listing);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult Get(string id)
        {
            var listing = listingFunction.GetById(id);
            return Ok(listing);
        }
        [HttpPost("Create")]
        public IActionResult Create()
        {
            var listingDto = new ListingDto();
            var files = Request.Form.Files;
            //  var listingDto = Request.Body.Form["ListingData"];// as ListingDto;
            var listingId = listingFunction.Create(listingDto);
            if (listingId is null)
                return BadRequest("There is problem while creating listing.");

            var rootPath = Path.Combine(webHost.WebRootPath, "ListingAttachments", listingId);
            Directory.CreateDirectory(rootPath);

            var attachments = new List<ListingAttachmentDto>();
            // store locally
            files.ToList().ForEach(file =>
            {
                var filePath = Path.Combine(rootPath, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                attachments.Add(new ListingAttachmentDto
                {
                    ProductId = listingId,
                    Type = "Image",
                    Url = filePath
                });
            });

            // save that path in database
            var id = listingFunction.AddAttachmentsToListing(attachments);

            return Ok(new ApiResponse { Success = (id > 0) });
        }
        [HttpPut("Update")]
        public IActionResult Update(ListingDto listingDto)
        {
            var listing = listingFunction.Update(listingDto);
            return Ok(listing);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(ListingDto listingDto)
        {
            var listing = listingFunction.Remove(listingDto);
            return Ok(listing);
        }

    }
}
