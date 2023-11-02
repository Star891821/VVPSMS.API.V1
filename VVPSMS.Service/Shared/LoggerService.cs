using VVPSMS.Domain.Logger.Models;
using VVPSMS.Service.Shared.Interfaces;

namespace VVPSMS.Service.Shared
{
    public class LoggerService:ILoggerService
    {
       private readonly VvpsmsdbLogsContext _vvpsmsdbLogsContext;
        public LoggerService(VvpsmsdbLogsContext vvpsmsdbLogsContext)
        {
            _vvpsmsdbLogsContext = vvpsmsdbLogsContext;
        }

        public void GetAllLogs()
        {
         // return  _vvpsmsdbLogsContext.Logs.ToList();
        }

    }
}
