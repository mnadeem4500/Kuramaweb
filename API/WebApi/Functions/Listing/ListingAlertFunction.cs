using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.WebApi.Dtos.Listing;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Listing
{
    public class ListingAlertFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public ListingAlertFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<ListingAlertFunction>();
            mapper = iMapper;
        }
        public List<ListingAlertsDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<ListingAlert>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<ListingAlertsDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<ListingAlertsDto>();
        }
        public ListingAlertsDto GetById(int Id)
        {
            var bll = new BLL<ListingAlert>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(Id);
                var category = mapper.Map<ListingAlert, ListingAlertsDto>(entities);
                return category;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(ListingAlertsDto listing)
        {
            var gbll = new BLL<ListingAlert>(settings.ConnectionString);
            try
            {
                var newlistingalert = mapper.Map<ListingAlertsDto, ListingAlert>(listing);
                newlistingalert.CreationDate = DateTime.UtcNow;
                newlistingalert.Active = true;
                gbll.Add(newlistingalert);
                return newlistingalert.NameField;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(ListingAlertsDto listing)
        {
            var bll = new BLL<ListingAlert>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(listing.Id);
                if (entities == null)
                    return OperationResponse.NotFound.ToString();

                entities.NameField = listing.UserId;
                entities.CategoryId = listing.CategoryId;
                entities.SearchContext = listing.SearchContext;
                entities.Active = listing.Active;
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
        public string Remove(ListingAlertsDto listing)
        {
            var dbll = new BLL<ListingAlert>(settings.ConnectionString);
            try
            {
                var entites = dbll.GetEntityById(listing.Id);
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
