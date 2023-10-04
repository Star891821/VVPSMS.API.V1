using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AcademicYearController : GenericController<MstAcademicYearDto>
    {
        public AcademicYearController(IGenericService<MstAcademicYearDto> genericService, ILog logger)
            : base(genericService, logger)
        {
        }
    }
}
