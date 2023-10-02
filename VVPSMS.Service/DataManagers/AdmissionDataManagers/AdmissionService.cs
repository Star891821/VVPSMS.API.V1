using VVPSMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using VVPSMS.Service.Repository.Admissions;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    public class AdmissionService : GenericService<AdmissionForm>, IAdmissionService
    {
        protected VvpsmsdbContext context;
        public AdmissionService(VvpsmsdbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> InsertOrUpdate(AdmissionForm entity)
        {
            try
            {
                var exist = getbyID(entity.FormId);
                if (exist != null)
                {
                    await base.Update(exist, UpdatedAdmissionEntity(exist, entity));// UpdatedAdmissionEntity(exist, entity));
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
            entityToUpdate.CreatedAt = DateTime.Now;
            entityToUpdate.CreatedBy = entity.CreatedBy;
            entityToUpdate.ModifiedAt = DateTime.Now;
            entityToUpdate.ModifiedBy = entity.ModifiedBy;
            return entityToUpdate;
        }

        public override async Task<AdmissionForm?> GetById(int id)
        {
            try
            {
                return getbyID(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private AdmissionForm getbyID(int id)
        {
            var admissionForm = dbSet.Where(x => x.FormId == id)
                                       .FirstOrDefault();
            if (admissionForm != null)
            {
                dbSet.Entry(admissionForm).Collection(adm => adm.StudentInfoDetails).Load();
                dbSet.Entry(admissionForm).Collection(adm => adm.AdmissionDocuments).Load();
                dbSet.Entry(admissionForm).Collection(adm => adm.AdmissionEnquiryDetails).Load();
                dbSet.Entry(admissionForm).Collection(adm => adm.SiblingInfos).Load();
                dbSet.Entry(admissionForm).Collection(adm => adm.StudentHealthInfoDetails).Load();
                dbSet.Entry(admissionForm).Collection(adm => adm.FamilyOrGuardianInfoDetails).Load();
                dbSet.Entry(admissionForm).Collection(adm => adm.PreviousSchoolDetails).Load();
                dbSet.Entry(admissionForm).Collection(adm => adm.EmergencyContactDetails).Load();
                dbSet.Entry(admissionForm).Collection(adm => adm.TransportDetails).Load();
                dbSet.Entry(admissionForm).Collection(adm => adm.StudentIllnessDetails).Load();
            }
            return admissionForm;
        }
        public override async Task<List<AdmissionForm>> GetAll()
        {
            return await dbSet.Include(a => a.StudentInfoDetails)
                .Include(a => a.StudentInfoDetails)
                .Include(a => a.AdmissionDocuments)
                .Include(a => a.AdmissionEnquiryDetails)
                .Include(a => a.SiblingInfos)
                .Include(a => a.StudentHealthInfoDetails)
                .Include(a => a.FamilyOrGuardianInfoDetails)
                .Include(a => a.PreviousSchoolDetails)
                .Include(a => a.EmergencyContactDetails)
                .Include(a => a.TransportDetails)
                .Include(a => a.StudentIllnessDetails)
                .ToListAsync();
        }
    }
}
