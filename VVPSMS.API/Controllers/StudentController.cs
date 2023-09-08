using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
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
        public StudentController(IStudentUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentDetails()
        {
            var users = await _unitOfWork.StudentService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentDetailsById(int id)
        {
            var item = await _unitOfWork.StudentService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentsByStudentId(int id)
        {
            var item = await _unitOfWork.DocumentService.GetAll(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateStudent(StudentDto studentDto)
        {

            var result = _mapper.Map<Student>(studentDto);
            var documents = _mapper.Map<List<StudentDocument>>(studentDto.Documents);
            await _unitOfWork.DocumentService.RemoveRange(documents);

            await _unitOfWork.StudentService.InsertOrUpdate(result);
            
            await _unitOfWork.CompleteAsync();

            return Ok();

        }



        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(StudentDto studentDto)
        {
            var result = _mapper.Map<Student>(studentDto);
            var item = await _unitOfWork.StudentService.Remove(result);
            var documents = _mapper.Map<List<StudentDocument>>(studentDto.Documents);
            await _unitOfWork.DocumentService.RemoveRange(documents);
            return Ok(item);
        }
    }
}
