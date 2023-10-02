using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IAdmissionUnitOfWork : IDisposable
    {
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

        Task CompleteAsync();

    }
}
