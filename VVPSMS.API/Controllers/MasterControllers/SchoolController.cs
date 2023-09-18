using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SchoolController : GenericController<MstSchoolDto>
    {
        public SchoolController(IGenericService<MstSchoolDto> genericService)
            : base(genericService)
        {

        }
    }
}
