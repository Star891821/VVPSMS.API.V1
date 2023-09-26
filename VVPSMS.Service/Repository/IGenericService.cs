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
