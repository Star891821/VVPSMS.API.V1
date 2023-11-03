using VVPSMS.Api.Models.Logger;

namespace VVPSMS.Service.Shared.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(LogsDto logsDto);

        void LogError(LogsDto logsDto);

        void LogDebug(LogsDto logsDto);

        void LogWarning(LogsDto logsDto);
    }
}
