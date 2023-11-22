using VVPSMS.Api.Models.Logger;
using VVPSMS.Domain.Logger.Models;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Shared.Interfaces
{
    public interface ILoggerService
    {
        List<LogsDto> GetAllLogs(int skip, int pageSize);

        List<LogsDto> GetLogDetails(string LogId);

        int GetAllLogsCount();
        void LogInfo(LogsDto logsDto);

        void LogError(LogsDto logsDto);

        void LogDebug(LogsDto logsDto);

        void LogWarning(LogsDto logsDto);
    }
}
