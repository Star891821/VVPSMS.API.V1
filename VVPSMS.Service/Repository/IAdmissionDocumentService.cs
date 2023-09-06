using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository
{
    public interface IAdmissionDocumentService
    {
        List<AdmissionDocumentDto> GetAllDocumentsById(int formId);
    }
}
