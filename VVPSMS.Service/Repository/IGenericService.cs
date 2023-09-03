using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Repository
{
    public interface IGenericService<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        List<T> InsertOrUpdate(T entity);
        List<T> Delete(int id);

    }
}
