using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.WebApi.Dtos.Listing;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Listing
{
    public class ListingVersionFunctions
    {

        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public ListingVersionFunctions(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<ListingVersionFunctions>();
            mapper = iMapper;
        }
        public List<ListingVersionDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<ListingVersion>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<ListingVersionDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<ListingVersionDto>();
        }
        public ListingVersionDto GetById(string id)
        {
            var bll = new BLL<ListingVersion>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(id);
                var listingversion = mapper.Map<ListingVersion, ListingVersionDto>(entities);
                return listingversion;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(ListingVersionDto listingversion)
        {
            var gbll = new BLL<ListingVersion>(settings.ConnectionString);
            try
            {
                var version = mapper.Map<ListingVersionDto, ListingVersion>(listingversion);
                version.NameField = listingversion.VersionName;
                version.VersionNumber = listingversion.VersionNumber;
                version.CreationDate = DateTime.UtcNow;
                version.Active = true;
                gbll.Add(version);
                return version.KeyField;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(ListingVersionDto listingVersion)
        {
            var bll = new BLL<ListingVersion>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(listingVersion.VersionName);
                if (entities == null)
                    return OperationResponse.NotFound.ToString();

                entities.NameField = listingVersion.VersionName;
                entities.VersionNumber = listingVersion.VersionNumber;
                entities.Active = listingVersion.Active;
                bll.Update(entities);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }
        public string Remove(ListingVersionDto listingversion)
        {
            var dbll = new BLL<ListingVersion>(settings.ConnectionString);
            try
            {
                var entites = dbll.GetEntityById(listingversion.VersionId);
                if (entites == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                dbll.Remove(entites);
                return OperationResponse.Deleted.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { dbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        }
}
