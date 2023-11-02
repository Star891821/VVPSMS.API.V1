using NLog;
using VVPSMS.Service.Shared;
using VVPSMS.Service.Shared.Interfaces;
using ILogger = NLog.ILogger;

namespace VVPSMS.API.NLog
{
    public class LogNLog : ILog
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _configuration;
        private string isLogToDatabase = string.Empty;
        private readonly ILoggerService _loggerService;
        public LogNLog(IConfiguration configuration,ILoggerService loggerService)
        {
            _loggerService= loggerService;
            _configuration = configuration;
            isLogToDatabase = _configuration["Logs:LogtoDatabase"]??"FALSE";
        }

        public void Information(string message)
        {
            if (isLogToDatabase == "TRUE")
            {
                
            }
            else
            {
                logger.Info(message);
            }            
        }

        public void Warning(string message)
        {
            if (isLogToDatabase == "TRUE")
            {

            }
            else
            {
                logger.Warn(message);
            }           
        }

        public void Debug(string message)
        {
            if (isLogToDatabase == "TRUE")
            {

            }
            else
            {
                logger.Debug(message);
            }           
        }

        public void Error(string message)
        {
            if (isLogToDatabase == "TRUE")
            {

            }
            else
            {
                logger.Error(message);
            }           
        }
    }
}
