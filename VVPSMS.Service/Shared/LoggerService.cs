
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.Enums;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Domain.Logger.Models;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;
using VVPSMS.Service.Shared.Interfaces;

namespace VVPSMS.Service.Shared
{
    public class LoggerService:ILoggerService
    {
        private readonly VvpsmsdbLogsContext _vvpsmsdbLogsContext;
        private IMapper _mapper;

        public LoggerService(VvpsmsdbLogsContext vvpsmsdbLogsContext, IMapper mapper)
        {
            _vvpsmsdbLogsContext = vvpsmsdbLogsContext;
            _mapper = mapper;
        }

        public void GetAllLogs()
        {
         // return  _vvpsmsdbLogsContext.Logs.ToList();
        }

        public void LogError(string msg)
        {

        }
        public void LogDebug(string msg)
        {

        }
        public void LogInfo(LogsDto logsDto)
        {
            using (var dbContext = new VvpsmsdbLogsContext())
            {
                if (logsDto != null)
                {
                    dbContext.Logs.Add(_mapper.Map<Log>(logsDto));
                    dbContext.SaveChanges();
                }
            }
        }
        public void LogWarning(string msg)
        {

        }
    }
}
