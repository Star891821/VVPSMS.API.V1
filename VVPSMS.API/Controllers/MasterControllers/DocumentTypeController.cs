using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : GenericController<MstDocumentTypesDto>
    {
        public DocumentTypeController(IGenericService<MstDocumentTypesDto> genericService)
           : base(genericService)
        {

        }
    }
}
