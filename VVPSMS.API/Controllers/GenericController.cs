using Microsoft.AspNetCore.Mvc;
using VVPSMS.API.Filters;
using VVPSMS.Service.Repository;

namespace VVPSMS.API.Controllers
{
    public class GenericController<T> : Controller where T:class 
    {
        private IGenericService<T> service;

        public  GenericController(IGenericService<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<T> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public T Get( int id)
        {
            return service.GetById(id);
        }


        [HttpPost, ActionName("InsertOrUpdate")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public bool Post([FromBody] T value) 
        {
            return service.InsertOrUpdate(value);
        
        }

        [HttpDelete]
        
        public bool Delete(int id)
        {
            return service.Delete(id);

        }
    }
}
