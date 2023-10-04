using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class UserController : GenericController<MstUserDto>
    {
        IUserService<MstUserDto> userService;
        private ILog _logger;
        public UserController(IUserService<MstUserDto> genericService, ILog logger)
            : base(genericService, logger)
        {
            userService = genericService;
            _logger = logger;

        }

        [HttpGet("{name}")]
        public IActionResult? GetUserByName(string name)
        {
            try
            {
                return Ok(userService.GetByName(name));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetUserByName for" + typeof(UserController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
        }
    }
}
