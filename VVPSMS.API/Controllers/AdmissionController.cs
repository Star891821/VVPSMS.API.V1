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
        public AdmissionController(IGenericService<AdmissionFormDto> genericService)
            : base(genericService)
        {

        }

    }
}
