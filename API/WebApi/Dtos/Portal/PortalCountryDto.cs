using ExtremeClassified.Domain.Portal;
using System.ComponentModel.DataAnnotations;

namespace ExtremeClassified.WebApi.Dtos.Portal
{
    public class PortalCountryDto : BaseDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string LangCode { get; set; }
        public string ISO { get; set; }
        public string ISO3 { get; set; }
        public int ISONumeric { get; set; }
        public string Capital { get; set; }
        public string ContinentCode { get; set; }
        public string CurrencyCode { get; set; }
        public List<CountryAdministrativeDivisionDto> CountryAdministrativeDivision { get; set; }

    }
    public class CountryAdministrativeDivisionDto :BaseDto
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string DivisionType { get; set; }

    }
}
