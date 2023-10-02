using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ClassController : GenericController<MstClassDto>
    {
        private static Logger logger = LogManager.GetLogger("ClassController");
        public ClassController(IGenericService<MstClassDto> genericService)
            : base(genericService)
        {

        }
    }
}
