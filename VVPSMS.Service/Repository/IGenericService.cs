namespace VVPSMS.Service.Repository
{
    public interface IGenericService<T>
    {
        List<T> GetAll();
        T? GetById(int id);  
        List<T> InsertOrUpdate(T entity);
        List<T> Delete(int id);

        //Task<IEnumerable<T>> All();
        //Task<T> GetById(Guid id);
        //Task<bool> Add(T entity);
        //Task<bool> Delete(Guid id);
        //Task<bool> Upsert(T entity);
        //Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

    }
}
