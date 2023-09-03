using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository
{
    public interface IAdmissionService
    {
        Task<CommonResponse> StudentAdmission(AdmissionFormDto admissionFormDto);
        IEnumerable<AdmissionFormDto> GetAllAdmissions();
        AdmissionFormDto? GetAdmissionById(int formId);
        CommonResponse DeleteAdmissionById(int formId);
    }
}
