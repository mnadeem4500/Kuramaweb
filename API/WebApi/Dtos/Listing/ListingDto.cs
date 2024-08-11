using ExtremeClassified.Domain.Listing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ExtremeClassified.Domain;

namespace ExtremeClassified.WebApi.Dtos.Listing
{
    public class ListingDto : BaseDto
    {
        public string ListingId { get; set; }
        public string SkU { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public double Price { get; set; }
        public string ThumbImage { get; set; }
        public bool IsPriceNegotiable { get; set; }
        public int CategoryId { get; set; }
        public List<ListingAttachmentDto> ListingAttachments { get; set; }
        public List<ListingPropertyDto> ListingProperties { get; set; }

    }
    public class ListingAttachmentDto : BaseDto
    {
        public int ListingAttachmentId { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string ProductId { get; set; }

    }
    public class ListingPropertyDto : BaseDto
    {

        public int Id { get; set; }
        public string ListingPropertyName { get; set; }
        public string PropertValue { get; set; }

    }
}
