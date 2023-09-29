using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IAdmissionDocumentService : ICommonService<AdmissionDocument>
    {
        void RemoveRangeofDocuments(int formid);

    }
}
