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
                var exist = getbyID(entity.FormId,null);
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
                return getbyID(id,null);
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

        public async Task<(List<AdmissionForm>, int)> GetAll(int PageNumber, int PageSize, int? StatusCode, string? name)
        {
            List<AdmissionForm> pagedData = new List<AdmissionForm>();
            int minStatuscode = 3;
            int maxStatuscode = 100;
            if (StatusCode == null && string.IsNullOrEmpty(name))
            {

                pagedData = await dbSet.Include(a => a.StudentInfoDetails)
                         .Where(a => (a.AdmissionStatus >= minStatuscode)
                          && (a.AdmissionStatus <= maxStatuscode))
                         .Include(a => a.AdmissionDocuments)
                         .Include(a => a.AdmissionEnquiryDetails)
                         .Include(a => a.SiblingInfos)
                         .Include(a => a.StudentHealthInfoDetails)
                         .Include(a => a.FamilyOrGuardianInfoDetails)
                         .Include(a => a.PreviousSchoolDetails)
                         .Include(a => a.EmergencyContactDetails)
                         .Include(a => a.TransportDetails)
                         .Include(a => a.StudentIllnessDetails)
                         .Skip((PageNumber - 1) * PageSize)
                         .Take(PageSize)
                         .ToListAsync();

            }
            else if (StatusCode == null && !string.IsNullOrEmpty(name))
            {
              var tempResult = await dbSet
                         .Where(a => a.AdmissionStatus >= minStatuscode
                          && a.AdmissionStatus <= maxStatuscode)
                         .Include(a => a.StudentInfoDetails.Where(o => o.FirstName.Contains(name)))
                        .Include(a => a.AdmissionDocuments)
                        .Include(a => a.AdmissionEnquiryDetails)
                        .Include(a => a.SiblingInfos)
                        .Include(a => a.StudentHealthInfoDetails)
                        .Include(a => a.FamilyOrGuardianInfoDetails)
                        .Include(a => a.PreviousSchoolDetails)
                        .Include(a => a.EmergencyContactDetails)
                        .Include(a => a.TransportDetails)
                        .Include(a => a.StudentIllnessDetails)
                        .Skip((PageNumber - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();
                foreach (var item in tempResult)
                {
                    if(item.StudentInfoDetails.Count > 0)
                    {
                        pagedData.Add(item);
                    }
                }
                
            }
            else if (StatusCode != null && string.IsNullOrEmpty(name))
            {
                pagedData = await dbSet.Include(a => a.StudentInfoDetails)
                        .Where(a => (a.AdmissionStatus == StatusCode))
                        .Include(a => a.AdmissionDocuments)
                        .Include(a => a.AdmissionEnquiryDetails)
                        .Include(a => a.SiblingInfos)
                        .Include(a => a.StudentHealthInfoDetails)
                        .Include(a => a.FamilyOrGuardianInfoDetails)
                        .Include(a => a.PreviousSchoolDetails)
                        .Include(a => a.EmergencyContactDetails)
                        .Include(a => a.TransportDetails)
                        .Include(a => a.StudentIllnessDetails)
                        .Skip((PageNumber - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();
            }
            else 
            {
                pagedData = await dbSet.Include(a => a.StudentInfoDetails)
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
                        .Skip((PageNumber - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();
            }
            var totalRecords = await dbSet.CountAsync();
            return (pagedData, totalRecords);
        }

        public async Task<List<AdmissionForm>> GetAdmissionDetailsByUserId(int userId)
        {

            try
            {
                return getAdmissionsbyID(userId);
            }
            catch
            {
                return null;
            }
        }

        public async Task<AdmissionForm> GetAdmissionDetailsByUserIdAndFormId(int id, int UserId)
        {

            try
            {
                return getbyID(id, UserId, true);
            }
            catch
            {
                return null;
            }
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
            entityToUpdate.CreatedAt = entity.CreatedAt;
            entityToUpdate.CreatedBy = entity.CreatedBy;
            entityToUpdate.ModifiedAt = entity.ModifiedAt;
            entityToUpdate.ModifiedBy = entity.ModifiedBy;
            return entityToUpdate;
        }
        private AdmissionForm getbyID(int? id, int? UserId, bool userWise = false)
        {
            var admissionForm = new AdmissionForm();
            try
            {
                if (userWise)
                {
                    admissionForm = dbSet.Where(x => x.CreatedBy == UserId && x.FormId == id).FirstOrDefault();
                }
                else
                {
                    admissionForm = dbSet.Where(x => x.FormId == id).FirstOrDefault();
                }
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
                    dbSet.Entry(admissionForm).State = EntityState.Detached;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return admissionForm;
        }

        private List<AdmissionForm> getAdmissionsbyID(int? UserId)
        {
            var listOfAdmissionForm = new List<AdmissionForm>();
            try
            {
                listOfAdmissionForm = dbSet.Where(x => x.CreatedBy == UserId).ToList();

                foreach (var item in listOfAdmissionForm)
                {
                    dbSet.Entry(item).Collection(adm => adm.StudentInfoDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.AdmissionDocuments).Load();
                    dbSet.Entry(item).Collection(adm => adm.AdmissionEnquiryDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.SiblingInfos).Load();
                    dbSet.Entry(item).Collection(adm => adm.StudentHealthInfoDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.FamilyOrGuardianInfoDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.PreviousSchoolDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.EmergencyContactDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.TransportDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.StudentIllnessDetails).Load();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfAdmissionForm;
        }

        #endregion
    }
}
