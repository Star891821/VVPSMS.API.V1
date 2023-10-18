using AutoMapper;
using VVPSMS.Domain.Models;
using VVPSMS.Service.DataManagers.DraftAdmissionDataManagers;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.Service.DataManagers.DraftAdmissionDataManagers
{
    /// <summary>
    /// AdmissionUnitOfWork
    /// </summary>
    public class DraftAdmissionUnitOfWork : IDraftAdmissionUnitOfWork
    {
        #region Private Declarations
        private readonly VvpsmsdbContext vvpsmsdbContext;
        private readonly IMapper mapper;
        #endregion

        #region public Declarations
        public IDraftAdmissionDocumentService DraftAdmissionDocumentService { get; private set; }
        public IDraftAdmissionService DraftAdmissionService { get; private set; }
        public IDraftAdmissionEnquiryDetails DraftAdmissionEnquiryDetailsService { get; private set; }
        public IDraftStudentHealthInfoDetails DraftStudentHealthInfoDetailsService { get; private set; }
        public IDraftStudentIllnessDetails DraftStudentIllnessDetailsService { get; private set; }
        public IDraftStudentInfoDetails DraftStudentInfoDetailsService { get; private set; }

        public IDraftTransportDetails DraftTransportDetailsService { get; private set; }

        public IDraftPreviousSchoolDetails DraftPreviousSchoolDetailsService { get; private set; }
        public IDraftSiblingInfosDetails DraftSiblingInfosDetailsService { get; private set; }
        public IDraftEmergencyContactDetails DraftEmergencyContactDetailsService { get; private set; }
        public IDraftFamilyOrGuardianInfoDetails DraftFamilyOrGuardianInfoDetailsService { get; private set; }
        #endregion


        #region public methods
        public DraftAdmissionUnitOfWork(VvpsmsdbContext vvpsmsdbContext, IMapper mapper)
        {
            this.vvpsmsdbContext = vvpsmsdbContext;
            this.mapper = mapper;
            DraftAdmissionDocumentService = new DraftAdmissionDocumentsService(vvpsmsdbContext);
            DraftAdmissionService = new DraftAdmissionService(vvpsmsdbContext);
            DraftAdmissionEnquiryDetailsService = new DraftAdmissionEnquiryDetails(vvpsmsdbContext);
            DraftStudentHealthInfoDetailsService = new DraftStudentHealthInfoDetails(vvpsmsdbContext);
            DraftStudentIllnessDetailsService = new DraftStudentIllnessDetails(vvpsmsdbContext);
            DraftStudentInfoDetailsService = new DraftStudentInfoDetails(vvpsmsdbContext);
            DraftTransportDetailsService = new DraftTransportDetailsService(vvpsmsdbContext);
            DraftPreviousSchoolDetailsService = new DraftPreviousSchoolDetailsService(vvpsmsdbContext);
            DraftSiblingInfosDetailsService = new DraftSiblingInfosDetailsService(vvpsmsdbContext);
            DraftEmergencyContactDetailsService = new DraftEmergencyContactDetailsService(vvpsmsdbContext);
            DraftFamilyOrGuardianInfoDetailsService = new DraftFamilyOrGuardianInfoDetailsService(vvpsmsdbContext);
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
            DraftAdmissionDocumentService.RemoveRangeofDetails();
            DraftAdmissionEnquiryDetailsService.RemoveRangeofDetails();
            DraftStudentHealthInfoDetailsService.RemoveRangeofDetails();
            DraftStudentInfoDetailsService.RemoveRangeofDetails();
            DraftStudentIllnessDetailsService.RemoveRangeofDetails();
            DraftTransportDetailsService.RemoveRangeofDetails();
            DraftSiblingInfosDetailsService.RemoveRangeofDetails();
            DraftPreviousSchoolDetailsService.RemoveRangeofDetails();
            DraftFamilyOrGuardianInfoDetailsService.RemoveRangeofDetails();
            DraftEmergencyContactDetailsService.RemoveRangeofDetails();
        }

       
        public void RemoveEntitiesById(int id)
        {
            DraftAdmissionDocumentService.RemoveRangeofDocuments(id);
            DraftAdmissionEnquiryDetailsService.RemoveRangeofDetailsById(id);
            DraftStudentHealthInfoDetailsService.RemoveRangeofDetailsById(id);
            DraftStudentInfoDetailsService.RemoveRangeofDetailsById(id);
            DraftStudentIllnessDetailsService.RemoveRangeofDetailsById(id);
            DraftTransportDetailsService.RemoveRangeofDetailsById(id);
            DraftSiblingInfosDetailsService.RemoveRangeofDetailsById(id);
            DraftPreviousSchoolDetailsService.RemoveRangeofDetailsById(id);
            DraftFamilyOrGuardianInfoDetailsService.RemoveRangeofDetailsById(id);
            DraftEmergencyContactDetailsService.RemoveRangeofDetailsById(id);
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
