using Microsoft.AspNetCore.Mvc;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.DataManagers;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : GenericController<MstUserDto>
    {
        private IConfiguration _configuration;
        IUserService<MstUserDto> userService;
        private ILog _logger;

        public UserController(IUserService<MstUserDto> genericService, ILog logger, IConfiguration configuration)
            : base(genericService, logger)
        {
            userService = genericService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("{name}")]
        public IActionResult? GetUserByName(string name)
        {
            try
            {
                _logger.Information($"GetUserByName API Started");
                return Ok(userService.GetByName(name));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetUserByName for" + typeof(UserController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetUserByName API completed Successfully");
            }
        }


        [HttpPost]
        public IActionResult EncryptPassword(string clearText)
        {
            var encryptionKey = _configuration["PassPhrase:Key"];
            StringEncryptionService a = new StringEncryptionService();
            var result = a.EncryptAsync(clearText, encryptionKey);
            return Ok(result.Result);
        }

        [HttpPost]
        public IActionResult DecryptPassword(string cipherText)
        {
            var encryptionKey = _configuration["PassPhrase:Key"];
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            StringEncryptionService a = new StringEncryptionService();
            var result = a.DecryptAsync(cipherBytes, encryptionKey);
            return Ok(result.Result);
        }

    }
}
