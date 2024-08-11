using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Controller.Portal;
using ExtremeClassified.WebApi.Dtos;
using ExtremeClassified.WebApi.Dtos.Portal;
using Microsoft.Extensions.Options;


namespace ExtremeClassified.WebApi.Functions.Portal
{
    public class PortalFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public PortalFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper mapper)
        {
            this.settings = options.Value;
            logger = loggerFactory.CreateLogger<PortalFunction>();
            this.mapper = mapper;
        }

        public List<PortalCountryDto> GetAllCountryWithDetails(bool onlyActive = true)
        {
            var bll = new BLL<PortalCountry>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAllWithNavigationProperties(x => x.KeyField != -1, n => n.CataloCountryAdministrativeDivisiongueDetails);

                return mapper.Map<List<PortalCountryDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<PortalCountryDto>();
        }
        public string CreatePortal(PortalCountryDto portal)
        {
            var bll = new BLL<PortalCountry>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<PortalCountryDto, PortalCountry>(portal);
                //entity.NameField = portal.CountryName;
                //entity.LangCode = portal.LangCode;
                //entity.ISO = portal.ISO;
                //entity.ISO3 = portal.ISO3;
                //entity.ISONumeric = portal.ISONumeric;
                //entity.Capital = portal.Capital;
                entity.CreationDate = DateTime.UtcNow;
                entity.Active = true;

                bll.Add(entity);

                return entity.KeyField.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }
       
        public string UpdatePortal(PortalCountryDto portal)
        {
            var bll = new BLL<PortalCountry>(settings.ConnectionString);
            try
            {
                var entity = bll.GetSingle(x => x.KeyField == portal.CountryId);
                if (entity is null)
                    return OperationResponse.NotFound.ToString();
                entity.NameField = portal.CountryName;
                entity.LangCode = portal.LangCode;
                entity.ISO = portal.ISO;
                entity.ISO3 = portal.ISO3;
                entity.ISONumeric = portal.ISONumeric;
                entity.Capital = portal.Capital;
                entity.NameField = portal.CountryName;
                entity.Active = portal.Active;


                bll.Update(entity);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }
        public string CreatCountryAdministrativeDivision(CountryAdministrativeDivisionDto detail)
        {
            var bll = new BLL<CountryAdministrativeDivision>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<CountryAdministrativeDivision>(detail);
                entity.CreationDate = DateTime.UtcNow;
                entity.Active = true;

                bll.Add(entity);

                return entity.NameField;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }
        public string UpdateCountryAdministrativeDivision(CountryAdministrativeDivisionDto detail)
        {
            var bll = new BLL<CountryAdministrativeDivision>(settings.ConnectionString);
            try
            {
                var entity = bll.GetSingle(x => x.KeyField == detail.id);
                if (entity is null)
                    return OperationResponse.NotFound.ToString();

                entity.NameField = detail.Name;
                entity.Active = detail.Active;
                entity.DivisionType = detail.DivisionType;


                bll.Update(entity);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }


    }
}
