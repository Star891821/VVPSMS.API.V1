using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Parents;

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
        public ParentController(IMapper mapper, IParentUnitOfWork unitOfWork, IConfiguration configuration, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        //[HttpPost("UpdateTeacherProfile")]
        //[Microsoft.AspNetCore.Authorization.Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllParentDetails()
        {
            try
            {
                _logger.Information($"GetAllParentDetails API Started");
                var users = await _unitOfWork.ParentService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllParentDetails for" + typeof(ParentController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllParentDetails API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParentDetailsById(int id)
        {
            try
            {
                _logger.Information($"GetParentDetailsById API Started");
                var item = await _unitOfWork.ParentService.GetById(id);

                if (item == null)
                {
                    _logger.Information($"GetParentDetailsById API returned Null");
                    return NotFound();
                }

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetParentDetailsById for" + typeof(ParentController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetParentDetailsById API completed Successfully");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentsByParentId(int id)
        {
            try
            {
                _logger.Information($"GetAllDocumentsByParentId API Started");
                var item = await _unitOfWork.DocumentService.GetAll(id);

                if (item == null)
                {
                    _logger.Information($"GetAllDocumentsByParentId API returned Null");
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllDocumentsByParentId for" + typeof(ParentController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAllDocumentsByParentId API completed Successfully");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateParent(ParentDto parentDto)
        {
            try
            {
                _logger.Information($"InsertOrUpdateParent API Started");
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
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"InsertOrUpdateParent API completed Successfully");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParent(ParentDto parentDto)
        {
            try
            {
                _logger.Information($"DeleteParent API Started");
                var result = _mapper.Map<Parent>(parentDto);
                var item = await _unitOfWork.ParentService.Remove(result);
                var documents = _mapper.Map<List<ParentDocument>>(parentDto.Documents);
                await _unitOfWork.DocumentService.RemoveRange(documents);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside DeleteParent for" + typeof(ParentController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"DeleteParent API completed Successfully");
            }
        }
    }
}
