using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos.Portal;

namespace ExtremeClassified.WebApi.Dtos.Listing
{
    public class CategoryDto : BaseDto
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Icon { get; set; }
        public int MaxAllowedImages { get; set; }
        public int PostValidity { get; set; }
        public List<CategoryPropertyDto> CategoryProperty { get; set; }
    }
    public class CategoryPropertyDto : BaseDto
    {
        public  int CategroyPrpertyId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string PropertyUnit { get; set; }
        public bool IsRequired { get; set; }
        public int CategoryId { get; set; }
        public int ScreenControlId { get; set; }
        public string CatalogueId { get; set; }
        

    }
}
