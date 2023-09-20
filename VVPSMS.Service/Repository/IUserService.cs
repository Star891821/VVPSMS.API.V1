namespace VVPSMS.Service.Repository
{
    public interface IUserService<T>:IGenericService<T>
    {
        T? GetByName(string name);
    }
}
