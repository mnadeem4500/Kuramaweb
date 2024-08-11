using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.WebApi.Dtos.Listing;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Listing
{
    public class CategoryPropertyFunction
    {

        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public CategoryPropertyFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<CategoryPropertyFunction>();
            mapper = iMapper;
        }
        public List<CategoryPropertyDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<CategoryProperty>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<CategoryPropertyDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<CategoryPropertyDto>();
        }
        public CategoryPropertyDto GetById(string Id)
        {
            var bll = new BLL<CategoryProperty>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(Id);
                var category = mapper.Map<CategoryProperty, CategoryPropertyDto>(entities);
                return category;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(CategoryPropertyDto category)
        {
            var gbll = new BLL<CategoryProperty>(settings.ConnectionString);
            try
            {
                var oldCategory = gbll.GetEntityByName(category.Name.ToUpper());
                if (oldCategory is not null)
                    return "There is already a Category with same name, please use another name.";
                var newCategory = mapper.Map<CategoryPropertyDto, CategoryProperty>(category);
                newCategory.CreationDate = DateTime.UtcNow;
                newCategory.Active = true;
                gbll.Add(newCategory);
                return string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(CategoryPropertyDto category)
        {
            var bll = new BLL<CategoryProperty>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(category.CategroyPrpertyId);
                if (entities == null)
                    return OperationResponse.NotFound.ToString();

                entities.NameField = category.Name;
                entities.Icon = category.Icon;
                entities.IsRequired = category.IsRequired;
                entities.PropertyUnit = category.PropertyUnit;
                entities.CategoryId = category.CategoryId;
                entities.CatalogueId = category.CatalogueId;
                entities.ScreenControlId = category.ScreenControlId;
                
                entities.Active = category.Active;
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
        public string Remove(CategoryPropertyDto category)
        {
            var dbll = new BLL<CategoryProperty>(settings.ConnectionString);
            try
            {
                var entites = dbll.GetEntityById(category.CategroyPrpertyId);
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
