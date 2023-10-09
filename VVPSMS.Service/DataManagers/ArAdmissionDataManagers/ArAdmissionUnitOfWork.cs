using AutoMapper;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.ArAdmissionDataManagers
{
    /// <summary>
    /// AdmissionUnitOfWork
    /// </summary>
    public class ArAdmissionUnitOfWork : IArAdmissionUnitOfWork
    {
        #region Private Declarations
        private readonly VvpsmsdbContext vvpsmsdbContext;
        private readonly IMapper mapper;
        #endregion

        #region public Declarations
        public IArAdmissionDocumentService ArAdmissionDocumentService { get; private set; }
        public IArAdmissionService ArAdmissionService { get; private set; }
        public IArAdmissionEnquiryDetails ArAdmissionEnquiryDetailsService { get; private set; }
        public IArStudentHealthInfoDetails ArStudentHealthInfoDetailsService { get; private set; }
        public IArStudentIllnessDetails ArStudentIllnessDetailsService { get; private set; }
        public IArStudentInfoDetails ArStudentInfoDetailsService { get; private set; }

        public IArTransportDetails ArTransportDetailsService { get; private set; }

        public IArPreviousSchoolDetails ArPreviousSchoolDetailsService { get; private set; }
        public IArSiblingInfosDetails ArSiblingInfosDetailsService { get; private set; }
        public IArEmergencyContactDetails ArEmergencyContactDetailsService { get; private set; }
        public IArFamilyOrGuardianInfoDetails ArFamilyOrGuardianInfoDetailsService { get; private set; }
        #endregion


        #region public methods
        public ArAdmissionUnitOfWork(VvpsmsdbContext vvpsmsdbContext, IMapper mapper)
        {
            this.vvpsmsdbContext = vvpsmsdbContext;
            this.mapper = mapper;
            ArAdmissionDocumentService = new ArAdmissionDocumentsService(vvpsmsdbContext);
            ArAdmissionService = new ArAdmissionService(vvpsmsdbContext);
            ArAdmissionEnquiryDetailsService = new ArAdmissionEnquiryDetails(vvpsmsdbContext);
            ArStudentHealthInfoDetailsService = new ArStudentHealthInfoDetails(vvpsmsdbContext);
            ArStudentIllnessDetailsService = new ArStudentIllnessDetails(vvpsmsdbContext);
            ArStudentInfoDetailsService = new ArStudentInfoDetails(vvpsmsdbContext);
            ArTransportDetailsService = new ArTransportDetailsService(vvpsmsdbContext);
            ArPreviousSchoolDetailsService = new ArPreviousSchoolDetailsService(vvpsmsdbContext);
            ArSiblingInfosDetailsService = new ArSiblingInfosDetailsService(vvpsmsdbContext);
            ArEmergencyContactDetailsService = new ArEmergencyContactDetailsService(vvpsmsdbContext);
            ArFamilyOrGuardianInfoDetailsService = new ArFamilyOrGuardianInfoDetailsService(vvpsmsdbContext);
        }

        public void Dispose()
        {
            vvpsmsdbContext.Dispose();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await vvpsmsdbContext.SaveChangesAsync() > 0;
        }
        public void RemoveNullableEntitiesFromDb()
        {
            ArAdmissionDocumentService.RemoveRangeofDetails();
            ArAdmissionEnquiryDetailsService.RemoveRangeofDetails();
            ArStudentHealthInfoDetailsService.RemoveRangeofDetails();
            ArStudentInfoDetailsService.RemoveRangeofDetails();
            ArStudentIllnessDetailsService.RemoveRangeofDetails();
            ArTransportDetailsService.RemoveRangeofDetails();
            ArSiblingInfosDetailsService.RemoveRangeofDetails();
            ArPreviousSchoolDetailsService.RemoveRangeofDetails();
            ArFamilyOrGuardianInfoDetailsService.RemoveRangeofDetails();
            ArEmergencyContactDetailsService.RemoveRangeofDetails();
        }

       
        public void RemoveEntitiesById(int id)
        {
            ArAdmissionDocumentService.RemoveRangeofDocuments(id);
            ArAdmissionEnquiryDetailsService.RemoveRangeofDetailsById(id);
            ArStudentHealthInfoDetailsService.RemoveRangeofDetailsById(id);
            ArStudentInfoDetailsService.RemoveRangeofDetailsById(id);
            ArStudentIllnessDetailsService.RemoveRangeofDetailsById(id);
            ArTransportDetailsService.RemoveRangeofDetailsById(id);
            ArSiblingInfosDetailsService.RemoveRangeofDetailsById(id);
            ArPreviousSchoolDetailsService.RemoveRangeofDetailsById(id);
            ArFamilyOrGuardianInfoDetailsService.RemoveRangeofDetailsById(id);
            ArEmergencyContactDetailsService.RemoveRangeofDetailsById(id);
        }
        public Task CompleteAsync()
        {
            return vvpsmsdbContext.SaveChangesAsync();
        }

        public bool Complete()
        {
            return vvpsmsdbContext.SaveChanges() > 0;
        }
        #endregion

    }
}
