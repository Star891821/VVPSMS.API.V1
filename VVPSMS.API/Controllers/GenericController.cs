using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
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
       // [Microsoft.AspNetCore.Authorization.Authorize]
        public List<T> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public T Get( int id)
        {
            return service.GetById(id);
        }

        [HttpPost, ActionName("InsertOrUpdate")]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public List<T> Post([FromBody] T value) 
        {
            return service.InsertOrUpdate(value);
        
        }

        [HttpDelete]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public List<T> Delete(int id)
        {
            return service.Delete(id);

        }
    }
}
