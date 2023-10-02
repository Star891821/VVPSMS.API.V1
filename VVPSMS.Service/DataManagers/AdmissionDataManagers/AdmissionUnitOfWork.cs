﻿using AutoMapper;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    public class AdmissionUnitOfWork : IAdmissionUnitOfWork
    {
        private readonly VvpsmsdbContext vvpsmsdbContext;
        private readonly IMapper mapper;
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
        public Task CompleteAsync()
        {
            return vvpsmsdbContext.SaveChangesAsync();
        }
    }
}
