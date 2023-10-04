using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserRoleController : GenericController<MstUserRoleDto>
    {
        public UserRoleController(IGenericService<MstUserRoleDto> genericService, ILog logger)
            : base(genericService, logger)
        {
            
        }
    }
}
