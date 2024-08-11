using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.WebApi.Dtos.Listing;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Listing
{
    public class ListingPropertyFunction
    {
        
            private readonly ApplicationSettings settings;
            private readonly ILogger logger;
            private readonly IMapper mapper;
            public ListingPropertyFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
            {
                settings = options.Value;
                logger = loggerFactory.CreateLogger<ListingPropertyFunction>();
                mapper = iMapper;
            }
            public List<ListingPropertyDto> GetAll(bool onlyActive = true)
            {
                var bll = new BLL<ListingProperty>(settings.ConnectionString);
                try
                {
                    var entities = bll.GetAll();

                    return mapper.Map<List<ListingPropertyDto>>(entities);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
                finally
                {
                    bll?.Dispose();
                }
                return new List<ListingPropertyDto>();
            }
            public ListingPropertyDto GetById(string Id)
            {
                var bll = new BLL<ListingProperty>(settings.ConnectionString);
                try
                {
                    var entities = bll.GetEntityById(Id);
                    var category = mapper.Map<ListingProperty, ListingPropertyDto>(entities);
                    return category;
                }
                catch (Exception ex)
                {
                    logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
                }
                finally { bll?.Dispose(); }

                return null;
            }
            public string Create(ListingPropertyDto listing)
            {
                var gbll = new BLL<ListingProperty>(settings.ConnectionString);
                try
                {
                    var newlistingproperty = mapper.Map<ListingPropertyDto, ListingProperty>(listing);
                     newlistingproperty.CreationDate = DateTime.UtcNow;
                     newlistingproperty.Active = true;
                     newlistingproperty.NameField = listing.ListingPropertyName;
                     newlistingproperty.PropertValue = listing.PropertValue;
                     gbll.Add(newlistingproperty);
                     return newlistingproperty.NameField;
                }
                catch (Exception ex)
                {
                    logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
                }
                finally { gbll?.Dispose(); }

                return OperationResponse.Error.ToString();

            }
            public string Update(ListingPropertyDto listing)
            {
                var bll = new BLL<ListingProperty>(settings.ConnectionString);
                try
                {
                    var entities = bll.GetEntityById(listing.Id);
                    if (entities == null)
                        return OperationResponse.NotFound.ToString();

                    entities.NameField = listing.ListingPropertyName;
                    entities.Active = listing.Active;
                    entities.PropertValue = listing.PropertValue;
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
            public string Remove(ListingPropertyDto listing)
            {
                var dbll = new BLL<ListingProperty>(settings.ConnectionString);
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
