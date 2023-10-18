using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;
using VVPSMS.Service.DataManagers.DraftAdmissionDataManagers;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.Service.Repository.DraftAdmissions
{
    public interface IDraftAdmissionUnitOfWork : IDisposable
    {
        IDraftAdmissionDocumentService DraftAdmissionDocumentService { get; }
        IDraftAdmissionService DraftAdmissionService { get; }
        IDraftAdmissionEnquiryDetails DraftAdmissionEnquiryDetailsService { get; }
        IDraftStudentHealthInfoDetails DraftStudentHealthInfoDetailsService { get; }
        IDraftStudentIllnessDetails DraftStudentIllnessDetailsService { get; }
        IDraftStudentInfoDetails DraftStudentInfoDetailsService { get; }
        IDraftTransportDetails DraftTransportDetailsService {  get; }
        IDraftEmergencyContactDetails DraftEmergencyContactDetailsService { get; }
        IDraftFamilyOrGuardianInfoDetails DraftFamilyOrGuardianInfoDetailsService { get; }
        IDraftPreviousSchoolDetails DraftPreviousSchoolDetailsService { get; }
        IDraftSiblingInfosDetails DraftSiblingInfosDetailsService { get; }
        
        void RemoveNullableEntitiesFromDb();
        void RemoveEntitiesById(int id);
        Task CompleteAsync();

        bool Complete();
    }
}
