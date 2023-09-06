using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Shared;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdmissionController : GenericController<AdmissionFormDto>
    {
        IAdmissionDocumentService admissionDocumentService;
        public AdmissionController(IGenericService<AdmissionFormDto> genericService, IAdmissionDocumentService documentService)
            : base(genericService)
        {
            admissionDocumentService = documentService;
        }

        [HttpGet("{id}"), ActionName("GetAllDocumentsById")]
        public List<AdmissionDocumentDto> GetAllDocumentsById(int id)
        {
            return admissionDocumentService.GetAllDocumentsById(id);
        }
    }
}
