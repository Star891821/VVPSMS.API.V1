﻿
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Domain.Logger.Models;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Shared.Interfaces;

namespace VVPSMS.Service.Shared
{
    public class LoggerService : ILoggerService
    {
        private readonly VvpsmsdbLogsContext _vvpsmsdbLogsContext;
        private IConfiguration _config;
        private IMapper _mapper;
        private int isLogLevel = 4;

        public LoggerService(VvpsmsdbLogsContext vvpsmsdbLogsContext, IMapper mapper, IConfiguration config)
        {
            _vvpsmsdbLogsContext = vvpsmsdbLogsContext;
            _mapper = mapper;
            _config = config;
            isLogLevel = Convert.ToInt16(_config["Logs:LogLevel"] ?? "4");
        }
        public List<LogsDto> GetAllLogs(int skip, int pageSize)
        {
            var query = _vvpsmsdbLogsContext.Logs.OrderByDescending(x => x.CreatedOn).Skip(skip);

            if (pageSize != -1)
            {
                query = query.Take(pageSize);
            }

            var result = query.ToList();
            return _mapper.Map<List<LogsDto>>(result);
        }
        public void LogError(LogsDto logsDto)
        {
            if (isLogLevel <= 4)
            {
                PushtoDB(logsDto);
            }
        }
        public void LogDebug(LogsDto logsDto)
        {
            if (isLogLevel <= 1)
            {
                PushtoDB(logsDto);
            }
        }
        public void LogInfo(LogsDto logsDto)
        {
            if (isLogLevel <= 2)
            {
                PushtoDB(logsDto);
            }
        }
        public void LogWarning(LogsDto logsDto)
        {
            if (isLogLevel <= 3)
            {
                PushtoDB(logsDto);
            }
        }

        private void PushtoDB(LogsDto logsDto)
        {
            if (logsDto != null)
            {
                _vvpsmsdbLogsContext.Logs.Add(_mapper.Map<Log>(logsDto));
                _vvpsmsdbLogsContext.SaveChanges();
            }
        }
    }
}
