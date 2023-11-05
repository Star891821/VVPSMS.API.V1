using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.Logger;
using VVPSMS.API.NLog;
using VVPSMS.Service.Filters;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Shared.Interfaces;
using LogLevel = NLog.LogLevel;

namespace VVPSMS.API.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private IGenericService<T> service;
        private ILog _logger;
        private readonly ILoggerService _loggerService;
        public GenericController(IGenericService<T> service, ILog logger, ILoggerService loggerService)
        {
            this.service = service;
            _logger = logger;
            _loggerService = loggerService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult? GetAll()
        {
            try
            {
                _logger.Information($"GetAll API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAll API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                return Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAll API for" + typeof(T).FullName + "entity with exception"+ ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAll for" + typeof(T).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally 
            {
                _logger.Information($"GetAll API Completed");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAll API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult? GetById(int id)
        {
            try
            {
                _logger.Information($"GetById API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetById API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                return Ok(service.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetById API for" + typeof(T).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetById for" + typeof(T).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetById API Completed");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetById API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }


        [HttpPost, ActionName("InsertOrUpdate")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize]
        public IActionResult Post([FromBody] T value)
        {
            try
            {
                _logger.Information($"InsertOrUpdate API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdate API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                return Ok(service.InsertOrUpdate(value));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate API for" + typeof(T).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at InsertOrUpdate for" + typeof(T).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"InsertOrUpdate API Completed");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdates API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.Information($"Delete API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                return Ok(service.Delete(id));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete API for" + typeof(T).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at Delete for" + typeof(T).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"Delete API Completed");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }
    }
}
