using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Listing
{
    public class ListingAlertsDto : BaseDto
    {
        
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public string SearchContext { get; set; }

    }
}
