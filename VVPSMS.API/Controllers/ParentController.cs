using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Parents;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ParentController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IParentUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        //private readonly IStorageService _storageService;
        public ParentController(IMapper mapper, IParentUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            // _storageService = new StorageService(_configuration);
        }

        //[HttpPost("UpdateTeacherProfile")]
        //[Microsoft.AspNetCore.Authorization.Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllParentDetails()
        {
            var users = await _unitOfWork.ParentService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParentDetailsById(int id)
        {
            var item = await _unitOfWork.ParentService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentsByParentId(int id)
        {
            var item = await _unitOfWork.DocumentService.GetAll(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateParent(ParentDto parentDto)
        {

            var result = _mapper.Map<Parent>(parentDto);
            var documents = _mapper.Map<List<ParentDocument>>(parentDto.Documents);
            await _unitOfWork.DocumentService.RemoveRange(documents);

            await _unitOfWork.ParentService.InsertOrUpdate(result);

            await _unitOfWork.CompleteAsync();

            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParent(ParentDto parentDto)
        {
            var result = _mapper.Map<Parent>(parentDto);
            var item = await _unitOfWork.ParentService.Remove(result);
            var documents = _mapper.Map<List<ParentDocument>>(parentDto.Documents);
            await _unitOfWork.DocumentService.RemoveRange(documents);
            return Ok(item);
        }
    }
}
