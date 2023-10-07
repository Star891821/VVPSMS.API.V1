using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Students;
using VVPSMS.Service.Shared;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IStudentUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILog _logger; 
        public StudentController(IStudentUnitOfWork unitOfWork, IMapper mapper, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentDetails()
        {
            try
            {
                _logger.Information($"GetAllStudentDetails API Started");
                var users = await _unitOfWork.StudentService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllStudentDetails for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllStudentDetails API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentDetailsById(int id)
        {
            try
            {
                _logger.Information($"GetStudentDetailsById API Started");
                var item = await _unitOfWork.StudentService.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetStudentDetailsById for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetStudentDetailsById API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentsByStudentId(int id)
        {
            try
            {
                _logger.Information($"GetAllDocumentsByStudentId API Started");
                var item = await _unitOfWork.DocumentService.GetAll(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByStudentId for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByStudentId API completed Successfully");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateStudent(StudentDto studentDto)
        {
            try
            {
                _logger.Information($"InsertOrUpdateStudent API Started");
                var result = _mapper.Map<Student>(studentDto);
                var documents = _mapper.Map<List<StudentDocument>>(studentDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);
                await _unitOfWork.StudentService.InsertOrUpdate(result);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdateStudent for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"InsertOrUpdateStudent API completed Successfully");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(StudentDto studentDto)
        {
            try
            {
                _logger.Information($"DeleteStudent API Started");
                var result = _mapper.Map<Student>(studentDto);
                var item = await _unitOfWork.StudentService.Remove(result);
                var documents = _mapper.Map<List<StudentDocument>>(studentDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside DeleteStudent for" + typeof(StudentController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"DeleteStudent API completed Successfully");
            }
        }
    }
}
