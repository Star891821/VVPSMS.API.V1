
using Microsoft.EntityFrameworkCore.Storage;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IAdmissionUnitOfWork : IDisposable
    {
        ITrackAdmissionStatusService TrackAdmissionStatusService { get; }
        IAdmissionDocumentService AdmissionDocumentService { get; }
        IAdmissionService AdmissionService { get; }
        IAdmissionEnquiryDetails AdmissionEnquiryDetailsService { get; }
        IStudentHealthInfoDetails StudentHealthInfoDetailsService { get; }  
        IStudentIllnessDetails StudentIllnessDetailsService { get; }
        IStudentInfoDetails StudentInfoDetailsService { get; }
        ITransportDetails TransportDetailsService {  get; }
        IEmergencyContactDetails EmergencyContactDetailsService { get; }
        IFamilyOrGuardianInfoDetails FamilyOrGuardianInfoDetailsService { get; }
        IPreviousSchoolDetails PreviousSchoolDetailsService { get; }
        ISiblingInfosDetails SiblingInfosDetailsService { get; }
        
        void RemoveNullableEntitiesFromDb();
        void RemoveEntitiesById(int id);
        Task CompleteAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollBack();
        bool Complete();
    }
}
