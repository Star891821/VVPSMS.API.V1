using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Shared;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IStudentService _dataRepository;
        private readonly IConfiguration _configuration;
        //private readonly IStorageService _storageService;
        public StudentController(IMapper mapper, IStudentService dataRepository, IConfiguration configuration)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
            _configuration = configuration;
           // _storageService = new StorageService(_configuration);
        }

        [HttpPost("UpdateStudentProfile")]
        public async Task<IActionResult> UpdateStudentProfile(StudentDto studentDto)
        {
            var response = await _dataRepository.UpdateStudentProfile(studentDto);
            if (response.Status)
            {
                // blob to store here
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }
    }
}
