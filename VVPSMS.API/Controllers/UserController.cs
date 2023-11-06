using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.DataManagers;
using VVPSMS.Service.Filters;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Shared.Interfaces;
using LogLevel = NLog.LogLevel;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        IUserService<MstUserDto> userService;
        private readonly ILoggerService _loggerService;
        private ILog _logger;

        public UserController(IUserService<MstUserDto> genericService, ILog logger, IConfiguration configuration, ILoggerService loggerService)
        {
            userService = genericService;
            _logger = logger;
            _configuration = configuration;
            _loggerService = loggerService;
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public IActionResult? GetUserByName(string name)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetUserByName API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetUserByName API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = userService.GetByName(name);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "UserByName data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetUserByName for" + typeof(UserController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetUserByName for" + typeof(UserController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetUserByName API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetUserByName API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }


        [HttpPost]
        [Authorize]
        public IActionResult EncryptPassword(string clearText)
        {
            var encryptionKey = _configuration["PassPhrase:Key"];
            StringEncryptionService a = new StringEncryptionService();
            var result = a.EncryptAsync(clearText, encryptionKey);
            return Ok(result.Result);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DecryptPassword(string cipherText)
        {
            var encryptionKey = _configuration["PassPhrase:Key"];
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            StringEncryptionService a = new StringEncryptionService();
            var result = a.DecryptAsync(cipherBytes, encryptionKey);
            return Ok(result.Result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult? GetAll()
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetAll API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAll API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = userService.GetAll();
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "GetAll data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAll API for" + typeof(UserController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAll for" + typeof(UserController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAll API Completed");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAll API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult? GetById(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetById API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetById API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item  = userService.GetById(id);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "GetById data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetById API for" + typeof(UserController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetById for" + typeof(UserController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetById API Completed");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetById API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }


        [HttpPost, ActionName("InsertOrUpdate")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [AllowAnonymous]
        public IActionResult Post([FromBody] MstUserDto values)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"InsertOrUpdate API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdate API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = userService.InsertOrUpdate(values);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "InsertOrUpdate data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate API for" + typeof(UserController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at InsertOrUpdate for" + typeof(UserController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"InsertOrUpdate API Completed");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdate API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"Delete API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = userService.Delete(id);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "Delete data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete API for" + typeof(UserController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at Delete for" + typeof(UserController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"Delete API Completed");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "Delete API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

    }
}
