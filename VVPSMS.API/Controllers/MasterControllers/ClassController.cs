using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ClassController : GenericController<MstClassDto>
    {
        public ClassController(IGenericService<MstClassDto> genericService, ILog logger)
            : base(genericService, logger)
        {

        }
    }
}
