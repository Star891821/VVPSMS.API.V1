
namespace VVPSMS.Service.Shared.Interfaces
{
    public interface IAzureSSOService<T>
    {
        T? GetByDomain(string domainName);
    }
}
