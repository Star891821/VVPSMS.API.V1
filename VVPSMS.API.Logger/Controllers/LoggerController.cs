using Microsoft.AspNetCore.Mvc;
using Nlog.API.Controllers;

namespace VVPSMS.API.Logger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> _logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> GetLogs()
        {
            _logger.LogDebug("This is a debug message");
            _logger.LogInformation("This is an info message");
            _logger.LogWarning("This is a warning message ");
            _logger.LogError(new Exception(), "This is an error message");

            return new string[] { "Cool", "Weather" };

        }
    }
}
