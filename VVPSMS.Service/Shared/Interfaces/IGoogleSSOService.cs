
namespace VVPSMS.Service.Shared.Interfaces
{
    public interface IGoogleSSOService<T>
    {
        T? GetByDomain(string domainName);
    }
}
