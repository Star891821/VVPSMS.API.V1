using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class UserController : GenericController<MstUserDto>
    {
        IUserService<MstUserDto> userService;
        private static Logger logger = LogManager.GetLogger("UserController");
        public UserController(IUserService<MstUserDto> genericService)
            : base(genericService)
        {
            userService = genericService;
          
        }

        [HttpGet("{name}")]
        public MstUserDto GetUserByName(string name)
        {
            return userService.GetByName(name);
        }
    }
}
