using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IArAdmissionDocumentService : ICommonService<ArAdmissionDocument>
    {
        void createDirectory(string directoryPath);
        void RemoveRangeofDetails();
        void RemoveRangeofDocuments(int formid);

    }
}
