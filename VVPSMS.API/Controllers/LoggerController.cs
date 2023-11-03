using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Logger.Models;
using VVPSMS.Service.DataManagers;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Shared;
using VVPSMS.Service.Shared.Interfaces;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private IConfiguration _configuration;
        ILoggerService _loggerService;
        private ILog _logger;

        public LoggerController(ILoggerService loggerService, ILog logger, IConfiguration configuration)
        {
            _loggerService = loggerService;
            _logger = logger;
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult? GetAll()
        {
            try
            {
                _logger.Information($"GetAll API Started");

                return Ok(_loggerService.GetAllLogs());
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAll API for" + typeof(UserController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAll API Completed");
            }
        }
    }
}
