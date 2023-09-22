using VVPSMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    public class AdmissionService : GenericService<AdmissionForm>, IAdmissionService
    {
        public AdmissionService(VvpsmsdbContext context) : base(context)
        {
        }

        public override async Task<bool> InsertOrUpdate(AdmissionForm entity)
        {
            try
            {
                var exist = await dbSet.Where(x => x.FormId == entity.FormId)
                                       .FirstOrDefaultAsync();

                if (exist != null)
                {
                    await base.InsertOrUpdate(UpdatedAdmissionEntity(exist, entity));
                }
                else
                {
                    await base.InsertOrUpdate(entity);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private AdmissionForm UpdatedAdmissionEntity(AdmissionForm entityToUpdate, AdmissionForm entity)
        {
            entityToUpdate.AcademicId = entity.AcademicId;
            entityToUpdate.SchoolId = entity.SchoolId;
            entityToUpdate.StreamId = entity.StreamId;
            entityToUpdate.GradeId = entity.GradeId;
            entityToUpdate.ClassId = entity.ClassId;
            entityToUpdate.AdmissionStatus = entity.AdmissionStatus;
            entityToUpdate.AdmissionDocuments = entity.AdmissionDocuments;
            entityToUpdate.AdmissionEnquiryDetails = entity.AdmissionEnquiryDetails;
            entityToUpdate.EmergencyContactDetails = entity.EmergencyContactDetails;
            entityToUpdate.FamilyOrGuardianInfoDetails = entity.FamilyOrGuardianInfoDetails;
            entityToUpdate.PreviousSchoolDetails = entity.PreviousSchoolDetails;
            entityToUpdate.SiblingInfos = entity.SiblingInfos;
            entityToUpdate.StudentHealthInfoDetails = entity.StudentHealthInfoDetails;
            entityToUpdate.StudentIllnessDetails = entity.StudentIllnessDetails;
            entityToUpdate.StudentInfoDetails = entity.StudentInfoDetails;
            entityToUpdate.TransportDetails = entity.TransportDetails;
            entityToUpdate.CreatedAt = entity.CreatedAt;
            entityToUpdate.CreatedBy = entity.CreatedBy;
            entityToUpdate.ModifiedAt = entity.ModifiedAt;
            entityToUpdate.ModifiedBy = entity.ModifiedBy;
            return entityToUpdate;
        }

    }
}
