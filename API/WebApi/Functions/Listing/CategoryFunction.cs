using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Dtos.Portal;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Listing
{
    public class CategoryFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment environment;
        public CategoryFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper, IWebHostEnvironment _environment)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<CategoryFunction>();
            mapper = iMapper;
            environment = _environment;
        }
        public List<CategoryDto> GetAll()
        {
            var bll = new BLL<Category>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<CategoryDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<CategoryDto>();
        }

        public List<CategoryDto> GetRootCatgories()
        {
            var bll = new BLL<Category>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll(x => x.ParentId == 0);

                return mapper.Map<List<CategoryDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<CategoryDto>();
        }
        public CategoryDto GetById(int Id)
        {
            var bll = new BLL<Category>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(Id);
                var category = mapper.Map<Category, CategoryDto>(entities);
                return category;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(CategoryDto category)
        {
            var gbll = new BLL<Category>(settings.ConnectionString);

            try
            {
                var newCategory = mapper.Map<CategoryDto, Category>(category);
                newCategory.CreationDate = DateTime.UtcNow;
                newCategory.Active = true;
               

                gbll.Add(newCategory);
                return OperationResponse.Created.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return null;

        }
        //public string Update(CategoryDto category)
        //{
        //    var bll = new BLL<Category>(settings.ConnectionString);
        //    try
        //    {
        //        var entities = bll.GetEntityById(category.Id);
        //        if (entities == null)
        //            return OperationResponse.NotFound.ToString();

        //        entities.NameField = category.Name;
        //        entities.ParentId = category.ParentId;
        //        entities.Icon = category.file;
        //        entities.MaxAllowedImages = category.MaxAllowedImages;
        //        entities.PostValidity = category.PostValidity;
        //        entities.Active = category.Active;
        //        bll.Update(entities);

        //        return OperationResponse.Updated.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
        //    }
        //    finally { bll?.Dispose(); }

        //    return null;
        //}
        public string Remove(CategoryDto category)
        {
            var dbll = new BLL<Category>(settings.ConnectionString);
            try
            {
                var entites = dbll.GetEntityById(category.Id);
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
