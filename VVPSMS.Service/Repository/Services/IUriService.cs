
using VVPSMS.Service.Filters;

namespace VVPSMS.Service.Repository.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
