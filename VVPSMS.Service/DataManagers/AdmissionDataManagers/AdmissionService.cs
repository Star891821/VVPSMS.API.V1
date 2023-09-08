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
            entityToUpdate.StudentGivenName = entity.StudentGivenName;
            entityToUpdate.StudentSurname = entity.StudentSurname;
            entityToUpdate.StudentDob = entity.StudentDob;
            entityToUpdate.StudentGender = entity.StudentGender;
            entityToUpdate.StudentAge = entity.StudentAge;
            entityToUpdate.ParentName1 = entity.ParentName1;
            entityToUpdate.HighestQualification1 = entity.HighestQualification1;
            entityToUpdate.ParentContact1 = entity.ParentContact1;
            entityToUpdate.ParentEmail1 = entity.ParentEmail1;
            entityToUpdate.ParentName2 = entity.ParentName2;
            entityToUpdate.HighestQualification2 = entity.HighestQualification2;
            entityToUpdate.ParentContact2 = entity.ParentContact2;
            entityToUpdate.ParentEmail2 = entity.ParentEmail2;
            entityToUpdate.PreferredContact = entity.PreferredContact;
            entityToUpdate.Declaration = entity.Declaration;
            entityToUpdate.SiblingsYn = entity.SiblingsYn;
            entityToUpdate.SpecialNeeds = entity.SpecialNeeds;
            entityToUpdate.LearningDisabilities = entity.LearningDisabilities;
            entityToUpdate.PreviousSchool = entity.PreviousSchool;
            entityToUpdate.ReasonDescription = entity.ReasonDescription;
            entityToUpdate.StudentExpelled = entity.StudentExpelled;
            entityToUpdate.DetailsExpulsion = entity.DetailsExpulsion;
            entityToUpdate.AdmissionStatus = entity.AdmissionStatus;
            entityToUpdate.CreatedAt = entity.CreatedAt;
            entityToUpdate.CreatedBy = entity.CreatedBy;
            entityToUpdate.ModifiedAt = entity.ModifiedAt;
            entityToUpdate.ModifiedBy = entity.ModifiedBy;
            return entityToUpdate;
        }

    }
}
