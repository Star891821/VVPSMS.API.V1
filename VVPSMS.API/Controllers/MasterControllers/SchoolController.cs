using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SchoolController : GenericController<MstSchoolDto>
    {
        private static Logger logger = LogManager.GetLogger("SchoolController");
        public SchoolController(IGenericService<MstSchoolDto> genericService)
            : base(genericService)
        {

        }
    }
}
