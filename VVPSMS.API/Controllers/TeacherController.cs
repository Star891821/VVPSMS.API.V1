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
    public class TeacherController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ITeacherService _dataRepository;
        private readonly IConfiguration _configuration;
        //private readonly IStorageService _storageService;
        public TeacherController(IMapper mapper, ITeacherService dataRepository, IConfiguration configuration)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
            _configuration = configuration;
            // _storageService = new StorageService(_configuration);
        }

        [HttpPost("UpdateTeacherProfile")]
        public async Task<IActionResult> UpdateTeacherProfile(TeacherDto teacherDto)
        {
            var response = await _dataRepository.UpdateTeacherProfile(teacherDto);
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
