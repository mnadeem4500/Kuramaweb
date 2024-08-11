using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.WebApi.Dtos.Listing;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Listing
{
    public class ListingAttachmentFuntion
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public ListingAttachmentFuntion(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<ListingAttachmentFuntion>();
            mapper = iMapper;
        }
        public List<ListingAttachmentDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<ListingAttachment>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<ListingAttachmentDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<ListingAttachmentDto>();
        }
        public ListingAttachmentDto GetById(int id)
        {
            var bll = new BLL<ListingAttachment>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(id);
                var listingattachment = mapper.Map<ListingAttachment, ListingAttachmentDto>(entities);
                return listingattachment;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(ListingAttachmentDto listingattachemnt)
        {
            var gbll = new BLL<ListingAttachment>(settings.ConnectionString);
            try
            {
                var attachment = mapper.Map<ListingAttachmentDto, ListingAttachment>(listingattachemnt);
                attachment.NameField = listingattachemnt.Type;
                attachment.ProductId = listingattachemnt.ProductId;
                attachment.CreationDate = DateTime.UtcNow;
                attachment.Active = true;
                gbll.Add(attachment);
                return attachment.NameField;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(ListingAttachmentDto listingAttachment)
        {
            var bll = new BLL<ListingAttachment>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(listingAttachment.ListingAttachmentId);
                if (entities == null)
                    return OperationResponse.NotFound.ToString();

                entities.NameField = listingAttachment.Type;
                entities.Active = listingAttachment.Active;
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
        public string Remove(ListingAttachmentDto listingAttachment)
        {
            var dbll = new BLL<ListingAttachment>(settings.ConnectionString);
            try
            {
                var entites = dbll.GetEntityById(listingAttachment.ListingAttachmentId);
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
