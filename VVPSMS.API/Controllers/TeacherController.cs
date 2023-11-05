using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Threading.Tasks;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Teachers;
using VVPSMS.Service.Shared;
using VVPSMS.Service.Shared.Interfaces;
using LogLevel = NLog.LogLevel;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class TeacherController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ITeacherUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ILoggerService _loggerService;
        //private readonly IStorageService _storageService;
        private ILog _logger;
        public TeacherController(IMapper mapper, ITeacherUnitOfWork unitOfWork, IConfiguration configuration, ILog logger, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            // _storageService = new StorageService(_configuration);
            _logger = logger;
            _loggerService = loggerService;
        }
       
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTeacherDetails()
        {
            try
            {
                _logger.Information($"GetAllTeacherDetails API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllTeacherDetails API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var users = await _unitOfWork.TeacherService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllTeacherDetails for" + typeof(TeacherController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllTeacherDetails for" + typeof(TeacherController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllTeacherDetails API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllTeacherDetails API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTeacherDetailsById(int id)
        {
            try
            {
                _logger.Information($"GetTeacherDetailsById API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetTeacherDetailsById API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = await _unitOfWork.TeacherService.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetTeacherDetailsById for" + typeof(TeacherController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetTeacherDetailsById for" + typeof(TeacherController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetTeacherDetailsById API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetTeacherDetailsById API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllDocumentsByTeacherId(int id)
        {
            try
            {
                _logger.Information($"GetAllDocumentsByTeacherId API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByTeacherId API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = await _unitOfWork.DocumentService.GetAll(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByTeacherId for" + typeof(TeacherController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllDocumentsByTeacherId for" + typeof(TeacherController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByTeacherId API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByTeacherId API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertOrUpdateTeacher(TeacherDto teacherDto)
        {
            try
            {
                _logger.Information($"InsertOrUpdateTeacher API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdateTeacher API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var result = _mapper.Map<Teacher>(teacherDto);
                var documents = _mapper.Map<List<TeacherDocument>>(teacherDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);

                await _unitOfWork.TeacherService.InsertOrUpdate(result);

                await _unitOfWork.CompleteAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdateTeacher for" + typeof(TeacherController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at InsertOrUpdateTeacher for" + typeof(TeacherController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"InsertOrUpdateTeacher API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdateTeacher API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteTeacher(TeacherDto teacherDto)
        {
            try
            {
                _logger.Information($"DeleteTeacher API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DeleteTeacher API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var result = _mapper.Map<Teacher>(teacherDto);
                var item = await _unitOfWork.TeacherService.Remove(result);
                var documents = _mapper.Map<List<TeacherDocument>>(teacherDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside DeleteTeacher for" + typeof(TeacherController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at DeleteTeacher for" + typeof(TeacherController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"DeleteTeacher API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DeleteTeacher API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
        }
    }
}
