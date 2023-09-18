using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : GenericController<MstUserDto>
    {
        public UserController(IGenericService<MstUserDto> genericService)
            : base(genericService)
        {

        }
    }
}
