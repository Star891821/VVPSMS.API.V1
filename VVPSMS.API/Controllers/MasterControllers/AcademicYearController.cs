using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AcademicYearController : GenericController<MstAcademicYearDto>
    {
        private static Logger logger = LogManager.GetLogger("AcademicYearController");
        public AcademicYearController(IGenericService<MstAcademicYearDto> genericService)
            : base(genericService)
        {

        }
    }
}
