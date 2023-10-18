using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository.DraftAdmissions
{
    public interface IDraftAdmissionDocumentService : ICommonService<ArAdmissionDocument>
    {
        void createDirectory(string directoryPath);
        void RemoveRangeofDetails();
        void RemoveRangeofDocuments(int formid);

    }
}
