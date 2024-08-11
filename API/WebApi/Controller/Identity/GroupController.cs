using ExtremeClassified.Core.Contracts;
using ExtremeClassified.DataAccess;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Functions.Identity;
using ExtremeClassified.WebApi.Functions.Listing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeClassified.WebApi.Controller.Identity
{
    [Route("[controller]")]
    public class GroupController : PortalBaseController
    {
        private readonly GroupFunctions groupFunctions;
        public GroupController(GroupFunctions groupFunctions)
        {
            this.groupFunctions = groupFunctions;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //  return Ok("<h4>Define Data </h4>");
            var grp = groupFunctions.GetAll();
            return Ok(grp);
        }

        [HttpGet("GetById/{groupdId}")]
        public IActionResult Get(string groupdId)
        {
            var grp = groupFunctions.GetById(groupdId);

            return Ok(grp);
        }
        [HttpPost("Create")]
        public IActionResult Create(GroupDto group)
        {
            var grp = groupFunctions.Create(group);
            if (grp == null)
            {
                return BadRequest("group is not Found");
            }

            return Ok(new { Name = grp, Des = group.Description });
        }
        [HttpPut("Update")]
        public IActionResult Update(GroupDto group)
        {
            var grp = groupFunctions.Update(group);
            return Ok(grp);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(GroupDto groupDto)
        {
            var grp = groupFunctions.Remove(groupDto);
            return Ok(grp);
        }
    }
}
