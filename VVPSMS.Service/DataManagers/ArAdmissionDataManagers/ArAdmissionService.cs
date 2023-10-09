using Microsoft.EntityFrameworkCore;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.ArAdmissionDataManagers
{
    /// <summary>
    /// AdmissionService
    /// </summary>
    public class ArAdmissionService : GenericService<ArAdmissionForm>, IArAdmissionService
    {
        #region Declarations
        protected VvpsmsdbContext context;
        #endregion
        #region public methods
        public ArAdmissionService(VvpsmsdbContext context) : base(context)
        {
            this.context = context;
        }
        public override async Task<bool> InsertOrUpdate(ArAdmissionForm entity)
        {
            try
            {
                var exist = getbyID(entity.ArformId);
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
        public override async Task<ArAdmissionForm?> GetById(int id)
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
        public override async Task<List<ArAdmissionForm>> GetAll()
        {
            return await dbSet.Include(a => a.ArStudentInfoDetails)
                .Include(a => a.ArStudentInfoDetails)
                .Include(a => a.ArAdmissionDocuments)
                .Include(a => a.ArAdmissionEnquiryDetails)
                .Include(a => a.ArSiblingInfos)
                .Include(a => a.ArStudentHealthInfoDetails)
                .Include(a => a.ArFamilyOrGuardianInfoDetails)
                .Include(a => a.ArPreviousSchoolDetails)
                .Include(a => a.ArEmergencyContactDetails)
                .Include(a => a.ArTransportDetails)
                .Include(a => a.ArStudentIllnessDetails)
                .ToListAsync();
        }
        #endregion

        #region Private Methods
        private ArAdmissionForm UpdatedAdmissionEntity(ArAdmissionForm entityToUpdate, ArAdmissionForm entity)
        {
            entityToUpdate.AcademicId = entity.AcademicId;
            entityToUpdate.SchoolId = entity.SchoolId;
            entityToUpdate.StreamId = entity.StreamId;
            entityToUpdate.GradeId = entity.GradeId;
            entityToUpdate.ClassId = entity.ClassId;
            entityToUpdate.AdmissionStatus = entity.AdmissionStatus;
            entityToUpdate.ArAdmissionDocuments = entity.ArAdmissionDocuments;
            entityToUpdate.ArAdmissionEnquiryDetails = entity.ArAdmissionEnquiryDetails;
            entityToUpdate.ArEmergencyContactDetails = entity.ArEmergencyContactDetails;
            entityToUpdate.ArFamilyOrGuardianInfoDetails = entity.ArFamilyOrGuardianInfoDetails;
            entityToUpdate.ArPreviousSchoolDetails = entity.ArPreviousSchoolDetails;
            entityToUpdate.ArSiblingInfos = entity.ArSiblingInfos;
            entityToUpdate.ArStudentHealthInfoDetails = entity.ArStudentHealthInfoDetails;
            entityToUpdate.ArStudentIllnessDetails = entity.ArStudentIllnessDetails;
            entityToUpdate.ArStudentInfoDetails = entity.ArStudentInfoDetails;
            entityToUpdate.ArTransportDetails = entity.ArTransportDetails;
            entityToUpdate.CreatedAt = entity.CreatedAt;
            entityToUpdate.CreatedBy = entity.CreatedBy;
            entityToUpdate.ModifiedAt = entity.ModifiedAt;
            entityToUpdate.ModifiedBy = entity.ModifiedBy;
            return entityToUpdate;
        }
        public ArAdmissionForm getbyID(int id)
        {
            var aradmissionForm = new ArAdmissionForm();
            try
            {
                aradmissionForm = dbSet.Where(x => x.ArformId == id)
                                      .FirstOrDefault();
                if (aradmissionForm != null)
                {
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArStudentInfoDetails).Load();
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArAdmissionDocuments).Load();
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArAdmissionEnquiryDetails).Load();
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArSiblingInfos).Load();
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArStudentHealthInfoDetails).Load();
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArFamilyOrGuardianInfoDetails).Load();
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArPreviousSchoolDetails).Load();
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArEmergencyContactDetails).Load();
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArTransportDetails).Load();
                    dbSet.Entry(aradmissionForm).Collection(adm => adm.ArStudentIllnessDetails).Load();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return aradmissionForm;
        }
        #endregion      
    }
}
