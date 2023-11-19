using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.Shared.Interfaces;
using LogLevel = NLog.LogLevel;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SSOController : Controller
    {
        private IConfiguration _configuration;
        IAzureSSOService<AzureBlobConfigurationDto> _azureSSOService;
        IGoogleSSOService<GoogleConfigurationDto> _googleSSOService;
        IMicroSoftSSOService<MicroSoftConfigurationDto> _microSoftSSOService;
        private readonly ILoggerService _loggerService;
        private ILog _logger;

        public SSOController(IGoogleSSOService<GoogleConfigurationDto> googlessoService, IMicroSoftSSOService<MicroSoftConfigurationDto> microsoftSSOService, IAzureSSOService<AzureBlobConfigurationDto> azuressoService, ILog logger, IConfiguration configuration, ILoggerService loggerService)
        {
            _googleSSOService = googlessoService;
            _microSoftSSOService = microsoftSSOService;
            _azureSSOService = azuressoService;
            _logger = logger;
            _configuration = configuration;
            _loggerService = loggerService;
        }

        [HttpGet("{domainName}")]
        [AllowAnonymous]
        public IActionResult? GetGoogleSSODetailsByDomainName(string domainName)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetGoogleSSODetailsByDomainName API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetGoogleSSODetailsByDomainName API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = _googleSSOService.GetByDomain(domainName);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "GetGoogleSSODetailsByDomainName data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetGoogleSSODetailsByDomainName for" + typeof(SSOController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetGoogleSSODetailsByDomainName for" + typeof(SSOController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetGoogleSSODetailsByDomainName API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetGoogleSSODetailsByDomainName API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{domainName}")]
        [AllowAnonymous]
        public IActionResult? GetMicroSoftSSODetailsByDomainName(string domainName)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetMicroSoftSSODetailsByDomainName API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetMicroSoftSSODetailsByDomainName API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = _microSoftSSOService.GetByDomain(domainName);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "GetMicroSoftSSODetailsByDomainName data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetMicroSoftSSODetailsByDomainName for" + typeof(SSOController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetMicroSoftSSODetailsByDomainName for" + typeof(SSOController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetMicroSoftSSODetailsByDomainName API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetMicroSoftSSODetailsByDomainName API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }


        [HttpGet("{domainName}")]
        [AllowAnonymous]
        public IActionResult? GetAzureSSODetailsByDomainName(string domainName)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetAzureSSODetailsByDomainName API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAzureSSODetailsByDomainName API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = _azureSSOService.GetByDomain(domainName);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "GetAzureSSODetailsByDomainName data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAzureSSODetailsByDomainName for" + typeof(SSOController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAzureSSODetailsByDomainName for" + typeof(SSOController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAzureSSODetailsByDomainName API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAzureSSODetailsByDomainName API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }
    }
}
