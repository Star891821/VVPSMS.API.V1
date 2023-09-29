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
        private Dictionary<string,string> filenamepathmapping = new Dictionary<string,string>();
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdate(AdmissionFormDto admissionFormDto)
        {
          
            if (admissionFormDto.ListOfFileContentsAsBase64 != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                foreach (var file in admissionFormDto.ListOfFileContentsAsBase64)
                {
                    var index = file.IndexOf(',');
                    var base64stringwithoutsignature = admissionFormDto.ListOfFileContentsAsBase64[0].Substring(index + 1);
                    index = admissionFormDto.ListOfFileContentsAsBase64[0].IndexOf(';');
                    var base64signature = admissionFormDto.ListOfFileContentsAsBase64[0].Substring(0, index);
                    index = base64signature.IndexOf("/");
                    var extension = base64signature.Substring(index + 1);

                    var filename1 =  DateTime.Now.Ticks.ToString() +"." +extension;
                    byte[] bytes = Convert.FromBase64String(base64stringwithoutsignature);
                    System.IO.File.WriteAllBytes(filePath + "\\"+filename1, bytes);
                    filenamepathmapping[filename1] = filePath;
                }
            }

            var result = _mapper.Map<AdmissionForm>(admissionFormDto);
            foreach(var a in filenamepathmapping)
            {
                AdmissionDocument admissionDocument = new AdmissionDocument()
                {
                    DocumentName = a.Key,
                    DocumentPath = a.Value,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    FormId = result.FormId,
                };
                result.AdmissionDocuments.Add(admissionDocument);
            }
            
             _unitOfWork.AdmissionDocumentService.RemoveRangeofDocuments(result.FormId);
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
