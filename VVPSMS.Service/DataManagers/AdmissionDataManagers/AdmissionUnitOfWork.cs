using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    /// <summary>
    /// AdmissionUnitOfWork
    /// </summary>
    public class AdmissionUnitOfWork : IAdmissionUnitOfWork
    {
        #region Private Declarations
        private readonly VvpsmsdbContext vvpsmsdbContext;
        private readonly IMapper mapper;
        #endregion

        #region public Declarations

        public ITrackAdmissionStatusService TrackAdmissionStatusService { get; private set; }
        public IAdmissionDocumentService AdmissionDocumentService { get; private set; }
        public IAdmissionService AdmissionService { get; private set; }
        public IAdmissionEnquiryDetails AdmissionEnquiryDetailsService { get; private set; }
        public IStudentHealthInfoDetails StudentHealthInfoDetailsService { get; private set; }
        public IStudentIllnessDetails StudentIllnessDetailsService { get; private set; }
        public IStudentInfoDetails StudentInfoDetailsService { get; private set; }

        public ITransportDetails TransportDetailsService { get; private set; }

        public IPreviousSchoolDetails PreviousSchoolDetailsService { get; private set; }
        public ISiblingInfosDetails SiblingInfosDetailsService { get; private set; }
        public IEmergencyContactDetails EmergencyContactDetailsService { get; private set; }
        public IFamilyOrGuardianInfoDetails FamilyOrGuardianInfoDetailsService { get; private set; }

        #endregion


        #region public methods
        public AdmissionUnitOfWork(VvpsmsdbContext vvpsmsdbContext, IMapper mapper)
        {
            this.vvpsmsdbContext = vvpsmsdbContext;
            this.mapper = mapper;
            AdmissionDocumentService = new AdmissionDocumentsService(vvpsmsdbContext);
            AdmissionService = new AdmissionService(vvpsmsdbContext);
            AdmissionEnquiryDetailsService = new AdmissionEnquiryDetails(vvpsmsdbContext);
            StudentHealthInfoDetailsService = new StudentHealthInfoDetails(vvpsmsdbContext);
            StudentIllnessDetailsService = new StudentIllnessDetails(vvpsmsdbContext);
            StudentInfoDetailsService = new StudentInfoDetails(vvpsmsdbContext);
            TransportDetailsService = new TransportDetailsService(vvpsmsdbContext);
            PreviousSchoolDetailsService = new PreviousSchoolDetailsService(vvpsmsdbContext);
            SiblingInfosDetailsService = new SiblingInfosDetailsService(vvpsmsdbContext);
            EmergencyContactDetailsService = new EmergencyContactDetailsService(vvpsmsdbContext);
            FamilyOrGuardianInfoDetailsService = new FamilyOrGuardianInfoDetailsService(vvpsmsdbContext);
            TrackAdmissionStatusService = new TrackAdmissionStatusService(vvpsmsdbContext);         
        }

        public void Dispose()
        {
            vvpsmsdbContext.Dispose();
        }

        public void BeginTransaction()
        {
            vvpsmsdbContext.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
             vvpsmsdbContext.Database.CommitTransaction();
        }

        public void RollBack()
        {
            vvpsmsdbContext.Database.RollbackTransaction();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await vvpsmsdbContext.SaveChangesAsync() > 0;
        }
        public void RemoveNullableEntitiesFromDb()
        {
            AdmissionDocumentService.RemoveRangeofDetails();
            AdmissionEnquiryDetailsService.RemoveRangeofDetails();
            StudentHealthInfoDetailsService.RemoveRangeofDetails();
            StudentInfoDetailsService.RemoveRangeofDetails();
            StudentIllnessDetailsService.RemoveRangeofDetails();
            TransportDetailsService.RemoveRangeofDetails();
            SiblingInfosDetailsService.RemoveRangeofDetails();
            PreviousSchoolDetailsService.RemoveRangeofDetails();
            FamilyOrGuardianInfoDetailsService.RemoveRangeofDetails();
            EmergencyContactDetailsService.RemoveRangeofDetails();
        }

       
        public void RemoveEntitiesById(int id)
        {
            AdmissionDocumentService.RemoveRangeofDocuments(id);
            AdmissionEnquiryDetailsService.RemoveRangeofDetailsById(id);
            StudentHealthInfoDetailsService.RemoveRangeofDetailsById(id);
            StudentInfoDetailsService.RemoveRangeofDetailsById(id);
            StudentIllnessDetailsService.RemoveRangeofDetailsById(id);
            TransportDetailsService.RemoveRangeofDetailsById(id);
            SiblingInfosDetailsService.RemoveRangeofDetailsById(id);
            PreviousSchoolDetailsService.RemoveRangeofDetailsById(id);
            FamilyOrGuardianInfoDetailsService.RemoveRangeofDetailsById(id);
            EmergencyContactDetailsService.RemoveRangeofDetailsById(id);
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
