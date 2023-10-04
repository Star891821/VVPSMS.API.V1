using Microsoft.AspNetCore.Mvc;
using VVPSMS.API.Filters;
using VVPSMS.API.NLog;
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
        public IActionResult? GetAll()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAll for" + typeof(T).FullName + "entity with exception"+ ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult? GetById(int id)
        {
            try
            {
                return Ok(service.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetById for" + typeof(T).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
        }


        [HttpPost, ActionName("InsertOrUpdate")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Post([FromBody] T value)
        {
            try
            {
                return Ok(service.InsertOrUpdate(value));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside InsertOrUpdate for" + typeof(T).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(service.Delete(id));
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside Delete for" + typeof(T).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
        }
    }
}
