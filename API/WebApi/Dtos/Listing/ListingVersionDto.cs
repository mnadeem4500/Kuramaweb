using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Listing
{
    public class ListingVersionDto : BaseDto
    {
      
        public string VersionId { get; set; } 
        public string VersionName { get; set; }
        public int VersionNumber { get; set; }
      
    }
}
