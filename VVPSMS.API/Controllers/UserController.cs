using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : GenericController<MstUserDto>
    {
        public UserController(IGenericService<MstUserDto> genericService)
            : base(genericService)
        {

        }
    }
}
