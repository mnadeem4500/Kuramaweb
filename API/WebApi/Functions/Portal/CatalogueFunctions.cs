using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Dtos.Portal;
using Microsoft.Extensions.Options;

namespace ExtremeClassified.WebApi.Functions.Portal
{
    public class CatalogueFunctions
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public CatalogueFunctions(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper mapper)
        {
            this.settings = options.Value;
            logger = loggerFactory.CreateLogger<CatalogueFunctions>();
            this.mapper = mapper;
        }


        public List<CatalogueMasterDto> GetAllMasterWithDetailsAll(bool onlyActive = true)
        {
            var bll = new BLL<CatalogueMaster>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAllWithNavigationProperties(x => x.KeyField != "Eh", n => n.CatalogueDetails);

                return mapper.Map<List<CatalogueMasterDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<CatalogueMasterDto>();
        }
        public string CreateMaster(CatalogueMasterDto catalogue)
        {
            var bll = new BLL<CatalogueMaster>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<CatalogueMaster>(catalogue);
                entity.CreationDate = DateTime.UtcNow;
                entity.Active = true;

                bll.Add(entity);

                return entity.KeyField;
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

        public string UpdateMaster(CatalogueMasterDto catalogue)
        {
            var bll = new BLL<CatalogueMaster>(settings.ConnectionString);
            try
            {
                var oldEntity = bll.GetSingle(x => x.KeyField == catalogue.MasterId);
                if (oldEntity is null)
                    return OperationResponse.NotFound.ToString();

                oldEntity.Description = catalogue.Description;
                oldEntity.NameField = catalogue.CatalogueName;
                //   oldEntity.CatalogueDetails = catalogue.CatalogueDetails[];


                bll.Update(oldEntity);

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


        public string CreateDetail(params CatalogueDetailDto[] detail)
        {
            var bll = new BLL<CatalogueDetail>(settings.ConnectionString);
            try
            {
                var entities = mapper.Map<List<CatalogueDetail>>(detail);
                entities.ForEach(entity =>
                {
                    entity.CreationDate = DateTime.UtcNow;
                    entity.Active = true;
                });
                bll.Add(entities.ToArray());

                return entities.FirstOrDefault().KeyField;
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

        public string UpdateDetail(params CatalogueDetailDto[] detail)
        {
            var bll = new BLL<CatalogueDetail>(settings.ConnectionString);
            try
            {
                var oldentity = bll.GetAll(x => x.MasterId == detail[0].MasterId);
                if (oldentity is null || oldentity.Count == 0)
                    return OperationResponse.NotFound.ToString();

                foreach (var entity in oldentity)
                {
                    var currentDetail = detail.FirstOrDefault(x => x.DetailId == entity.KeyField);
                    entity.NameField = currentDetail.Name;
                    entity.MasterId = currentDetail.MasterId;
                }

                bll.Update(oldentity.ToArray());

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


        public string Remove(string masterId)
        {
            var bll = new BLL<CatalogueMaster>(settings.ConnectionString);
            var detailsBll = new BLL<CatalogueDetail>(settings.ConnectionString);

            try
            {
                var masterEntity = bll.GetSingle(x => x.KeyField == masterId);

                if (masterEntity is null)
                    return OperationResponse.NotFound.ToString();

                var details = detailsBll.GetAll(x => x.MasterId == masterId);

                detailsBll.Remove(details.ToArray());

                bll.Remove(masterEntity);

                return OperationResponse.Deleted.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
                detailsBll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }



    }
}
