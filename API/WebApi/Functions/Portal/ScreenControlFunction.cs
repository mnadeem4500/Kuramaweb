using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos.Portal;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Portal
{
    public class ScreenControlFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public ScreenControlFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<ScreenControlFunction>();
            mapper = iMapper;
        }
        public List<ScreenControlDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<ScreenControl>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<ScreenControlDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<ScreenControlDto>();
        }
        public ScreenControlDto GetById(int screen)
        {
            var bll = new BLL<ScreenControl>(settings.ConnectionString);

            try
            {
                var entities = bll.GetEntityById(screen);
                var screencontrol = mapper.Map<ScreenControl, ScreenControlDto>(entities);
                return screencontrol;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(ScreenControlDto screen)
        {
            var gbll = new BLL<ScreenControl>(settings.ConnectionString);
            try
            {
                var oldControl = gbll.GetEntityByName(screen.Name.ToUpper());
                if (oldControl is not null)
                    return "There is already a control with same name, please use another name.";
                var screenContol = mapper.Map<ScreenControlDto, ScreenControl>(screen);
                screenContol.CreationDate = DateTime.UtcNow;
                screenContol.Active = true;
                gbll.Add(screenContol);
                return string.Empty;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(ScreenControlDto screen)
        {
            var bll = new BLL<ScreenControl>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(screen.Id);
                if (entities == null)
                    return OperationResponse.NotFound.ToString();

                entities.NameField = screen.Name;
                //entities.Active = screen.Active;
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
        public string Remove(ScreenControlDto screen)
        {
            var dbll = new BLL<ScreenControl>(settings.ConnectionString);
            try
            {
                var entites = dbll.GetEntityById(screen.Id);
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
