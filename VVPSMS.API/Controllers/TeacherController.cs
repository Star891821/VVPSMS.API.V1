using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Teachers;
using VVPSMS.Service.Shared;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class TeacherController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ITeacherUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        //private readonly IStorageService _storageService;
        private ILog _logger;
        public TeacherController(IMapper mapper, ITeacherUnitOfWork unitOfWork, IConfiguration configuration, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            // _storageService = new StorageService(_configuration);
            _logger = logger;
        }
       
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTeacherDetails()
        {
            try
            {
                _logger.Information($"GetAllTeacherDetails API Started");
                var users = await _unitOfWork.TeacherService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllTeacherDetails for" + typeof(TeacherController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllTeacherDetails API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTeacherDetailsById(int id)
        {
            try
            {
                _logger.Information($"GetTeacherDetailsById API Started");
                var item = await _unitOfWork.TeacherService.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetTeacherDetailsById for" + typeof(TeacherController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetTeacherDetailsById API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllDocumentsByTeacherId(int id)
        {
            try
            {
                _logger.Information($"GetAllDocumentsByTeacherId API Started");
                var item = await _unitOfWork.DocumentService.GetAll(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByTeacherId for" + typeof(TeacherController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByTeacherId API completed Successfully");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertOrUpdateTeacher(TeacherDto teacherDto)
        {
            try
            {
                _logger.Information($"InsertOrUpdateTeacher API Started");
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
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"InsertOrUpdateTeacher API completed Successfully");
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteTeacher(TeacherDto teacherDto)
        {
            try
            {
                _logger.Information($"DeleteTeacher API Started");
                var result = _mapper.Map<Teacher>(teacherDto);
                var item = await _unitOfWork.TeacherService.Remove(result);
                var documents = _mapper.Map<List<TeacherDocument>>(teacherDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside DeleteTeacher for" + typeof(TeacherController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"DeleteTeacher API completed Successfully");
            }
        }
    }
}
