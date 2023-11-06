using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.Logger;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Students;
using VVPSMS.Service.Shared.Interfaces;
using LogLevel = NLog.LogLevel;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IStudentUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILog _logger;
        private readonly ILoggerService _loggerService;
        public StudentController(IStudentUnitOfWork unitOfWork, IMapper mapper, ILog logger, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _loggerService = loggerService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllStudentDetails()
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetAllStudentDetails API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllStudentDetails API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var users = await _unitOfWork.StudentService.GetAll();
                if (users == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "AllStudentDetails data is not found";
                }
                else
                {
                    value = users;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllStudentDetails for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllStudentDetails for" + typeof(StudentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAllStudentDetails API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllStudentDetails API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetStudentDetailsById(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetStudentDetailsById API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetStudentDetailsById API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = await _unitOfWork.StudentService.GetById(id);

                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "StudentDetailsById data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetStudentDetailsById for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetStudentDetailsById for" + typeof(StudentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetStudentDetailsById API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetStudentDetailsById API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllDocumentsByStudentId(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"GetAllDocumentsByStudentId API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByStudentId API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var item = await _unitOfWork.DocumentService.GetAll(id);

                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "AllDocumentsByStudentId data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByStudentId for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at GetAllDocumentsByStudentId for" + typeof(StudentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByStudentId API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "GetAllDocumentsByStudentId API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertOrUpdateStudent(StudentDto studentDto)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"InsertOrUpdateStudent API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdateStudent API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var result = _mapper.Map<Student>(studentDto);
                var documents = _mapper.Map<List<StudentDocument>>(studentDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);
                await _unitOfWork.StudentService.InsertOrUpdate(result);
                await _unitOfWork.CompleteAsync();
                if (result == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "InsertOrUpdateStudent data is not found";
                }
                else
                {
                    value = result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdateStudent for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at InsertOrUpdateStudent for" + typeof(StudentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"InsertOrUpdateStudent API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "InsertOrUpdateStudent API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteStudent(StudentDto studentDto)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                _logger.Information($"DeleteStudent API Started");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DeleteStudent API Started", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                var result = _mapper.Map<Student>(studentDto);
                var item = await _unitOfWork.StudentService.Remove(result);
                var documents = _mapper.Map<List<StudentDocument>>(studentDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "DeleteStudent data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside DeleteStudent for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                _loggerService.LogError(new LogsDto() { CreatedOn = DateTime.Now, Exception = ex.Message + "-" + ex.InnerException, Level = LogLevel.Error.ToString(), Message = "Exception at DeleteStudent for" + typeof(StudentController).FullName + "entity with exception", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            finally
            {
                _logger.Information($"DeleteStudent API completed Successfully");
                _loggerService.LogInfo(new LogsDto() { CreatedOn = DateTime.Now, Exception = "", Level = LogLevel.Info.ToString(), Message = "DeleteStudent API Completed Successfully", Url = Request.GetDisplayUrl(), StackTrace = Environment.StackTrace, Logger = "" });
            }
            return StatusCode(statusCode, value);
        }
    }
}
