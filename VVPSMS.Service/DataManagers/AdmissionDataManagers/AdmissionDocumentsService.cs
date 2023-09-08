using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    public class AdmissionDocumentsService : GenericService<AdmissionDocument>, IAdmissionDocumentService
    {
        public AdmissionDocumentsService(VvpsmsdbContext context) : base(context) { }

    }
}
