using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Portal
{
    [Table("PortalCountries")]
    public class PortalCountry : CommonEntity
    {
        [Key, Column("CountryId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int KeyField { get; set; }

        [Required, Column("CountryName", TypeName = "NVARCHAR"), MaxLength(255)]
        public new string NameField { get; set; }

        [Required, MaxLength(50)]
        public string LangCode { get; set; }

        [MaxLength(50)]
        public string ISO { get; set; }

        [MaxLength(50)]
        public string ISO3 { get; set; }
        public int ISONumeric { get; set; }

        [MaxLength(150)]
        public string Capital { get; set; }

        [MaxLength(50)]
        public string ContinentCode { get; set; }

        [MaxLength(50)]
        public string CurrencyCode { get; set; }
        // this is not add in domain we want this or not 
        public virtual ICollection<CountryAdministrativeDivision> CataloCountryAdministrativeDivisiongueDetails { get; set; }

    }
}
