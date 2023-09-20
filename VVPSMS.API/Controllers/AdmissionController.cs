using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public AdmissionController(IAdmissionUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmissionDetails()
        {
            var users = await _unitOfWork.AdmissionService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmissionDetailsById(int id)
        {
            var item = await _unitOfWork.AdmissionService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDocumentsByAdmissionId(int id)
        {
            var item = await _unitOfWork.AdmissionDocumentService.GetAll(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdate(AdmissionFormDto admissionFormDto)
        {

            var result = _mapper.Map<AdmissionForm>(admissionFormDto);
            var documents = _mapper.Map<List<AdmissionDocument>>(admissionFormDto.listOfAdmissionDocuments);
            await _unitOfWork.AdmissionDocumentService.RemoveRange(documents);
            await _unitOfWork.AdmissionService.InsertOrUpdate(result);
            
            await _unitOfWork.CompleteAsync();

            return Ok();

        }

      

        [HttpDelete]
        public async Task<IActionResult> Delete(AdmissionFormDto admissionFormDto)
        {
            var result = _mapper.Map<AdmissionForm>(admissionFormDto);
            var item = await _unitOfWork.AdmissionService.Remove(result);
            var documents = _mapper.Map<List<AdmissionDocument>>(admissionFormDto.listOfAdmissionDocuments);
            await _unitOfWork.AdmissionDocumentService.RemoveRange(documents);
            return Ok(item);
        }
    }
}
