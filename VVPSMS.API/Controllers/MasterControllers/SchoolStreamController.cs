using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SchoolStreamController : GenericController<MstSchoolStreamDto>
    {
        private static Logger logger = LogManager.GetLogger("SchoolStreamController");
        public SchoolStreamController(IGenericService<MstSchoolStreamDto> genericService)
            : base(genericService)
        {

        }
    }
}
