using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SchoolGradeController : GenericController<MstSchoolGradeDto>
    {
        private static Logger logger = LogManager.GetLogger("SchoolGradeController");
        public SchoolGradeController(IGenericService<MstSchoolGradeDto> genericService)
            : base(genericService)
        {

        }
    }
}
