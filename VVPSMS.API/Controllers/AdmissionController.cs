using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.SqlServer.Server;
using System.Text;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AdmissionController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IAdmissionUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public AdmissionController(IAdmissionUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
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
            var isUploadtoAzure =  _configuration["Upoad:IsUpoadtoAzure"];
            var filePath = _configuration["Upoad:SaveFilePath"];
            var result = _mapper.Map<AdmissionForm>(admissionFormDto);
            if (isUploadtoAzure == "Yes")
            {

            }
            else
            {
                if (admissionFormDto.listOfAdmissionDocuments != null)
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    for (var i = 0; i < admissionFormDto.listOfAdmissionDocuments.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(admissionFormDto.listOfAdmissionDocuments[i].FileContentsAsBase64))
                        {
                            var Base64FileContent = admissionFormDto.listOfAdmissionDocuments[i].FileContentsAsBase64;
                            var index = Base64FileContent.IndexOf(',');
                            var base64stringwithoutsignature = Base64FileContent.Substring(index + 1);
                            byte[] bytes = Convert.FromBase64String(base64stringwithoutsignature);
                            System.IO.File.WriteAllBytes(filePath + "\\" + admissionFormDto.listOfAdmissionDocuments[i].DocumentName, bytes);
                            AdmissionDocument admissionDocument = new()
                            {
                                DocumentName = admissionFormDto.listOfAdmissionDocuments[i].DocumentName,
                                DocumentPath = filePath,
                                FormId = admissionFormDto.listOfAdmissionDocuments[i].FormId,
                                MstdocumenttypesId = admissionFormDto.listOfAdmissionDocuments[i].MstdocumenttypesId,
                                CreatedAt = DateTime.Now,
                                ModifiedAt = DateTime.Now,
                            };
                            result.AdmissionDocuments.Add(admissionDocument);
                        }

                    }
                }

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
