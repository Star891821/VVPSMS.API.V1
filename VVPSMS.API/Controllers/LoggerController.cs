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
using Azure.Storage.Blobs.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Text.RegularExpressions;

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
        public IActionResult? GetLogDetails(string LogId)
        {
            try
            {
                var logDetails = _loggerService.GetLogDetails(LogId);

                if (logDetails != null)
                {
                    _logger.Information($"GetLogDetails API Completed. LogId: {LogId}");
                    return Ok(logDetails);
                }
                else
                {
                    _logger.Information($"Log details not found for LogId: {LogId}");
                    return NotFound(); // Return 404 if log details are not found
                }
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
                var hi = HttpContext.Request.Query["jsonData"].ToString();
                var draw = HttpContext.Request.Query["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Query["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Query["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Query["columns[" + Request.Query["order[1][data]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                //iSortCol gives your Column numebr of for which sorting is required
                int iSortCol = Convert.ToInt32(Request.Query["order[0][column]"].FirstOrDefault());

                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Query["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Query["search[value]"].FirstOrDefault();

                var fromDate = Request.Query["fromDate"].FirstOrDefault();
                var toDate = Request.Query["toDate"].FirstOrDefault();
                var level = Request.Query["level"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var result = _loggerService.GetAllLogs(skip, pageSize);
                var totalrecordscount = _loggerService.GetAllLogsCount();
                var logsData = (from templogdata in result select templogdata);

                logsData = logsData.OrderByDescending(x => x.CreatedOn);

                if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
                {
                    DateTime fromCreatedOn = DateTime.ParseExact(fromDate, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime toCreatedOn = DateTime.ParseExact(toDate, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                    logsData = logsData.Where(x => x.CreatedOn >= fromCreatedOn
                           && x.CreatedOn <= toCreatedOn.AddDays(1).AddTicks(-1));
                }

                if (!string.IsNullOrEmpty(level))
                {
                    logsData = logsData.Where(x => x.Level == level);
                }
                

                if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
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
                                                //|| m.FormId.Contains(searchValue));

                    // Call SortFunction to provide sorted Data, then Skip using iDisplayStart  
                    logsData = SortFunction(iSortCol, sortColumnDirection, logsData).ToList();
                }

                // Call SortFunction to provide sorted Data, then Skip using iDisplayStart  
                logsData = SortFunction(iSortCol, sortColumnDirection, logsData).ToList();

                //total number of rows count   
                recordsTotal = logsData.Count();


                //Paging   
                //if (pageSize == -1)
                //{
                //    logsData = logsData.Skip(skip);
                //}
                //else
                //{
                //    logsData = logsData.Skip(skip).Take(pageSize);
                //}

                //Returning Json Data  
                var jsonData = (new { draw = draw, recordsFiltered = totalrecordscount, recordsTotal = totalrecordscount, data = logsData });
                return Ok(jsonData);
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Sorting Function
        private IEnumerable<LogsDto> SortFunction(int iSortCol, string sortOrder, IEnumerable<LogsDto> list)
        {

            //Sorting for String columns
            if (iSortCol == 1 || iSortCol == 2 || iSortCol == 3 || iSortCol == 4 || iSortCol == 5 || iSortCol == 6 || iSortCol == 7)
            {
                Func<LogsDto, object> orderingFunction = (c =>
                {
                    switch (iSortCol)
                    {
                        case 1:
                            return c.CreatedOn;
                        case 2:
                            return c.Level;
                        case 3:
                            return c.Message;
                        case 4:
                            return c.StackTrace;
                        case 5:
                            return c.Exception;
                        case 6:
                            return c.Logger;
                        case 7:
                            return c.Url;
                        //case 8:
                        //    return c.FormId;
                        default:
                            // Default sorting column when iSortCol doesn't match any specified column
                            return c.CreatedOn;
                    }
                });
                

                if (sortOrder == "desc")
                {
                    list = list.OrderByDescending(orderingFunction).ToList();
                }
                else
                {
                    list = list.OrderBy(orderingFunction).ToList();

                }
            }
            //Sorting for Int columns
            else if (iSortCol == 0)
            {
                Func<LogsDto, int> orderingFunction = (c => iSortCol == 0 ? c.Id : c.Id); // compare the sorting column

                if (sortOrder == "desc")
                {
                    list = list.OrderByDescending(orderingFunction).ToList();
                }
                else
                {
                    list = list.OrderBy(orderingFunction).ToList();

                }
            }

            return list;
        }
    }
}
