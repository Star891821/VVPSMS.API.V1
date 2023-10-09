using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;
using VVPSMS.Service.DataManagers.AdmissionDataManagers;
using VVPSMS.Service.DataManagers.ArAdmissionDataManagers;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IArAdmissionUnitOfWork : IDisposable
    {
        IArAdmissionDocumentService ArAdmissionDocumentService { get; }
        IArAdmissionService ArAdmissionService { get; }
        IArAdmissionEnquiryDetails ArAdmissionEnquiryDetailsService { get; }
        IArStudentHealthInfoDetails ArStudentHealthInfoDetailsService { get; }
        IArStudentIllnessDetails ArStudentIllnessDetailsService { get; }
        IArStudentInfoDetails ArStudentInfoDetailsService { get; }
        IArTransportDetails ArTransportDetailsService {  get; }
        IArEmergencyContactDetails ArEmergencyContactDetailsService { get; }
        IArFamilyOrGuardianInfoDetails ArFamilyOrGuardianInfoDetailsService { get; }
        IArPreviousSchoolDetails ArPreviousSchoolDetailsService { get; }
        IArSiblingInfosDetails ArSiblingInfosDetailsService { get; }
        
        void RemoveNullableEntitiesFromDb();
        void RemoveEntitiesById(int id);
        Task CompleteAsync();

        bool Complete();
    }
}
