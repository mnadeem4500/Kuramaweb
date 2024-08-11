using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.WebApi.Dtos.Listing;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Listing
{
    public class ListingFavoriteFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public ListingFavoriteFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<ListingFavoriteFunction>();
            mapper = iMapper;
        }
        public List<ListingFavoriteDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<ListingFavorite>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<ListingFavoriteDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<ListingFavoriteDto>();
        }
        public ListingFavoriteDto GetById(string Id)
        {
            var bll = new BLL<ListingFavorite>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(Id);
                var category = mapper.Map<ListingFavorite, ListingFavoriteDto>(entities);
                return category;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(ListingFavoriteDto listing)
        {
            var gbll = new BLL<ListingFavorite>(settings.ConnectionString);
            try
            {
                var newlistingfavorite = mapper.Map<ListingFavoriteDto, ListingFavorite>(listing);
                newlistingfavorite.CreationDate = DateTime.UtcNow;
                newlistingfavorite.Active = true;
                newlistingfavorite.NameField = listing.Title;
                newlistingfavorite.UserId = listing.UserId;

                gbll.Add(newlistingfavorite);
                return newlistingfavorite.NameField;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(ListingFavoriteDto listing)
        {
            var bll = new BLL<ListingFavorite>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(listing.Id);
                if (entities == null)
                    return OperationResponse.NotFound.ToString();

                entities.NameField = listing.Title;
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
        public string Remove(ListingFavoriteDto listing)
        {
            var dbll = new BLL<ListingFavorite>(settings.ConnectionString);
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

