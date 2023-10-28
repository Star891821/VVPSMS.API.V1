using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.NLog;
using VVPSMS.Service.Filters;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserRoleController : ControllerBase 
    {
        IGenericService<MstUserRoleDto> GenericService;
        private ILog _logger;
        public UserRoleController(IGenericService<MstUserRoleDto> genericService, ILog logger)
        {
            GenericService = genericService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult? GetAll()
        {
            try
            {
                _logger.Information($"GetAll API Started");

                return Ok(GenericService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAll API for" + typeof(UserRoleController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetAll API Completed");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult? GetById(int id)
        {
            try
            {
                _logger.Information($"GetById API Started");
                return Ok(GenericService.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetById API for" + typeof(UserRoleController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetById API Completed");
            }
        }


        [HttpPost, ActionName("InsertOrUpdate")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [AllowAnonymous]
        public IActionResult Post([FromBody] MstUserRoleDto value)
        {
            try
            {
                _logger.Information($"InsertOrUpdate API Started");
                return Ok(GenericService.InsertOrUpdate(value));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate API for" + typeof(UserRoleController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"InsertOrUpdate API Completed");
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.Information($"Delete API Started");
                return Ok(GenericService.Delete(id));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete API for" + typeof(UserRoleController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"Delete API Completed");
            }
        }

    }
}
