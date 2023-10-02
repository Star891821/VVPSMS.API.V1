using Microsoft.EntityFrameworkCore;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    /// <summary>
    /// AdmissionService
    /// </summary>
    public class AdmissionService : GenericService<AdmissionForm>, IAdmissionService
    {
        #region Declarations
        protected VvpsmsdbContext context;
        #endregion
        #region public methods
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
            catch
            {
                return false;
            }
        }
        public override async Task<AdmissionForm?> GetById(int id)
        {
            try
            {
                return getbyID(id);
            }
            catch
            {
                return null;
            }
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
        #endregion

        #region Private Methods
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
        private AdmissionForm getbyID(int id)
        {
            var admissionForm = new AdmissionForm();
            try
            {
                admissionForm = dbSet.Where(x => x.FormId == id)
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

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return admissionForm;
        }
        #endregion      
    }
}
