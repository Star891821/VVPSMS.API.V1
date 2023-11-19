
namespace VVPSMS.Service.Shared.Interfaces
{
    public interface IMicroSoftSSOService<T>
    {
        T? GetByDomain(string domainName);
    }
}
