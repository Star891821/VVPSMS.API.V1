using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SchoolStreamController : GenericController<MstSchoolStreamDto>
    {
        public SchoolStreamController(IGenericService<MstSchoolStreamDto> genericService)
            : base(genericService)
        {

        }
    }
}
