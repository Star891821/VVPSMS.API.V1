using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
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
        private static Logger logger = LogManager.GetLogger("TeacherController");
        public TeacherController(IMapper mapper, ITeacherUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            // _storageService = new StorageService(_configuration);
        }

        //[HttpPost("UpdateTeacherProfile")]
        //[Microsoft.AspNetCore.Authorization.Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllTeacherDetails()
        {
            var users = await _unitOfWork.TeacherService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherDetailsById(int id)
        {
            var item = await _unitOfWork.TeacherService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentsByTeacherId(int id)
        {
            var item = await _unitOfWork.DocumentService.GetAll(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateStudent(TeacherDto teacherDto)
        {

            var result = _mapper.Map<Teacher>(teacherDto);
            var documents = _mapper.Map<List<TeacherDocument>>(teacherDto.Documents);
            await _unitOfWork.DocumentService.RemoveRange(documents);

            await _unitOfWork.TeacherService.InsertOrUpdate(result);

            await _unitOfWork.CompleteAsync();

            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(TeacherDto teacherDto)
        {
            var result = _mapper.Map<Teacher>(teacherDto);
            var item = await _unitOfWork.TeacherService.Remove(result);
            var documents = _mapper.Map<List<TeacherDocument>>(teacherDto.Documents);
            await _unitOfWork.DocumentService.RemoveRange(documents);
            return Ok(item);
        }
    }
}
