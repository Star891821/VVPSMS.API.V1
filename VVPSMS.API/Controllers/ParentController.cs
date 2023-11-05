using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Parents;
using VVPSMS.Service.Shared.Interfaces;
using LogLevel = NLog.LogLevel;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ParentController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IParentUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private ILog _logger;
        private readonly ILoggerService _loggerService;
        public ParentController(IMapper mapper, IParentUnitOfWork unitOfWork, IConfiguration configuration, ILog logger, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
            _loggerService = loggerService;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllParentDetails()
        {
            try
            {
                _logger.Information($"GetAllParentDetails API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllParentDetails API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                var users = await _unitOfWork.ParentService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllParentDetails for" + typeof(ParentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllParentDetails for" + typeof(ParentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllParentDetails API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllParentDetails API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetParentDetailsById(int id)
        {
            try
            {
                _logger.Information($"GetParentDetailsById API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetParentDetailsById API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                var item = await _unitOfWork.ParentService.GetById(id);

                if (item == null)
                {
                    _logger.Information($"GetParentDetailsById API returned Null");
                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetParentDetailsById API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                    return NotFound();
                }

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetParentDetailsById for" + typeof(ParentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetParentDetailsById for" + typeof(ParentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetParentDetailsById API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetParentDetailsById API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllDocumentsByParentId(int id)
        {
            try
            {
                _logger.Information($"GetAllDocumentsByParentId API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByParentId API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                var item = await _unitOfWork.DocumentService.GetAll(id);

                if (item == null)
                {
                    _logger.Information($"GetAllDocumentsByParentId API returned Null");
                    _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByParentId API returned Null", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByParentId for" + typeof(ParentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllDocumentsByParentId for" + typeof(ParentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByParentId API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByParentId API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertOrUpdateParent(ParentDto parentDto)
        {
            try
            {
                _logger.Information($"InsertOrUpdateParent API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdateParent API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                var result = _mapper.Map<Parent>(parentDto);
                var documents = _mapper.Map<List<ParentDocument>>(parentDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);

                await _unitOfWork.ParentService.InsertOrUpdate(result);

                await _unitOfWork.CompleteAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdateParent for" + typeof(ParentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at InsertOrUpdateParent for" + typeof(ParentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"InsertOrUpdateParent API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdateParent API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteParent(ParentDto parentDto)
        {
            try
            {
                _logger.Information($"DeleteParent API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DeleteParent API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });

                var result = _mapper.Map<Parent>(parentDto);
                var item = await _unitOfWork.ParentService.Remove(result);
                var documents = _mapper.Map<List<ParentDocument>>(parentDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside DeleteParent for" + typeof(ParentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at DeleteParent for" + typeof(ParentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"DeleteParent API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DeleteParent API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }
    }
}
