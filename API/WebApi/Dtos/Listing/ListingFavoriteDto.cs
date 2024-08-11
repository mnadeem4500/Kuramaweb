using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Listing
{
    public class ListingFavoriteDto :BaseDto
    {
        
        public string Id { get; set; } 
        public  string Title { get; set; }
        public string UserId { get; set; }

    }
}
