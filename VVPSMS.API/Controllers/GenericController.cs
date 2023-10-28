using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMS.API.NLog;
using VVPSMS.Service.Filters;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private IGenericService<T> service;
        private ILog _logger;
        public GenericController(IGenericService<T> service, ILog logger)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult? GetAll()
        {
            try
            {
                _logger.Information($"GetAll API Started");

                return Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAll API for" + typeof(T).FullName + "entity with exception"+ ex.Message);
                return StatusCode(500);
            }
            finally 
            {
                _logger.Information($"GetAll API Completed");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult? GetById(int id)
        {
            try
            {
                _logger.Information($"GetById API Started");
                return Ok(service.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetById API for" + typeof(T).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"GetById API Completed");
            }
        }


        [HttpPost, ActionName("InsertOrUpdate")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize]
        public IActionResult Post([FromBody] T value)
        {
            try
            {
                _logger.Information($"InsertOrUpdate API Started");
                return Ok(service.InsertOrUpdate(value));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate API for" + typeof(T).FullName + "entity with exception" + ex.Message);
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
                return Ok(service.Delete(id));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete API for" + typeof(T).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                _logger.Information($"Delete API Completed");
            }
        }
    }
}
