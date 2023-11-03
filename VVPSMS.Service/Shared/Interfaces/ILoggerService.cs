using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.Logger;

namespace VVPSMS.Service.Shared.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(LogsDto logsDto);

        void LogError(LogsDto logsDto);
    }
}
