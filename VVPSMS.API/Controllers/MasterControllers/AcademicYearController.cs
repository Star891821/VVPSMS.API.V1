using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AcademicYearController : GenericController<MstAcademicYearDto>
    {
        public AcademicYearController(IGenericService<MstAcademicYearDto> genericService)
            : base(genericService)
        {

        }
    }
}
