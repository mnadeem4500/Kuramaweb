using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Dtos.Portal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Listing
{
    public class ListingFunction
    {


        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public ListingFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<ListingFunction>();
            mapper = iMapper;
        }
        public List<ListingDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<Domain.Listing.Listing>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<ListingDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<ListingDto>();
        }
        public ListingDto GetById(string Id)
        {
            var bll = new BLL<Domain.Listing.Listing>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(Id);
                var category = mapper.Map<Domain.Listing.Listing, ListingDto>(entities);
                return category;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(ListingDto listing)
        {
            var gbll = new BLL<Domain.Listing.Listing>(settings.ConnectionString);
            try
            {
                var newlisting = mapper.Map<ListingDto, Domain.Listing.Listing>(listing);
                newlisting.CreationDate = DateTime.UtcNow;
                newlisting.Active = true;
                gbll.Add(newlisting);
                return newlisting.KeyField;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return null;

        }

        public int AddAttachmentsToListing(List<ListingAttachmentDto> attachments)
        {
            var gbll = new BLL<Domain.Listing.ListingAttachment>(settings.ConnectionString);
            try
            {
                var entities = mapper.Map<List<Domain.Listing.ListingAttachment>>(attachments);
                entities.ForEach(x =>
                {
                    x.CreationDate = DateTime.UtcNow;
                    x.Active = true;
                });
                gbll.Add(entities.ToArray());
                return entities.FirstOrDefault().KeyField;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return 0;

        }
        public string Update(ListingDto listing)
        {
            var bll = new BLL<Domain.Listing.Listing>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(listing.ListingId);
                if (entities == null)
                    return OperationResponse.NotFound.ToString();

                entities.NameField = listing.ListingId;
                entities.Active = listing.Active;
                entities.Price = listing.Price;
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
        public string Remove(ListingDto listing)
        {
            var dbll = new BLL<Domain.Listing.Listing>(settings.ConnectionString);
            try
            {
                var entites = dbll.GetEntityById(listing.ListingId);
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

