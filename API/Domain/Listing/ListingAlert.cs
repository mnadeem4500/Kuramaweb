using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Listing
{

    [Table("ListingAlerts")]
    public class ListingAlert : EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int KeyField { get; set; }

        [Required, MaxLength(36)]
        public new string NameField { get; set; }
        public int CategoryId { get; set; }

        [MaxLength(250)]
        public string SearchContext { get; set; }

    }
}
