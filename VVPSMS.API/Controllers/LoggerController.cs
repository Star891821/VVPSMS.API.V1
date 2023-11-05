using Castle.Core.Resource;
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
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Query["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Query["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Query["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Query["columns[" + Request.Query["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Query["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Query["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var result = _loggerService.GetAllLogs();
                var logsData = (from templogdata in result select templogdata);
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    if (sortColumnDirection == "asc")
                    {
                        logsData = logsData.OrderBy(s => sortColumn);
                    }
                    else
                    {
                        logsData = logsData.OrderByDescending(s => sortColumn);
                    }
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    logsData = logsData.Where(m => m.Id.ToString().Contains(searchValue)
                                                || m.CreatedOn.ToString().Contains(searchValue)
                                                || m.Level.Contains(searchValue)
                                                || m.Message.Contains(searchValue)
                                                || m.StackTrace.Contains(searchValue)
                                                || m.Exception.Contains(searchValue)
                                                || m.Logger.Contains(searchValue)
                                                || m.Url.Contains(searchValue));
                }

                //total number of rows count   
                recordsTotal = logsData.Count();
                //Paging   
                var data = logsData.Skip(skip).ToList();
                //Returning Json Data  
                var jsonData = (new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
                return Ok(jsonData);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
