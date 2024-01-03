using Microsoft.EntityFrameworkCore;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Filters;
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
                var exist = getbyID(entity.FormId, null);


                if (exist != null)
                {
                    AdmissionForm existingEntity = context.Set<AdmissionForm>().Local.FirstOrDefault(e => e.FormId == entity.FormId);

                    if (existingEntity == null)
                    {
                        context.Entry(entity).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(existingEntity).CurrentValues.SetValues(entity);

                        UpdateChildEntities(existingEntity.AdmissionDocuments, entity.AdmissionDocuments, (a, b) => a.DocumentId == b.DocumentId);
                        UpdateChildEntities(existingEntity.AdmissionEnquiryDetails, entity.AdmissionEnquiryDetails, (a, b) => a.AdmissionenquirydetailsId == b.AdmissionenquirydetailsId);
                        UpdateChildEntities(existingEntity.EmergencyContactDetails, entity.EmergencyContactDetails, (a, b) => a.EmergencycontactdetailsId == b.EmergencycontactdetailsId);
                        UpdateChildEntities(existingEntity.FamilyOrGuardianInfoDetails, entity.FamilyOrGuardianInfoDetails, (a, b) => a.FamilyorguardianinfodetailsId == b.FamilyorguardianinfodetailsId);
                        UpdateChildEntities(existingEntity.PreviousSchoolDetails, entity.PreviousSchoolDetails, (a, b) => a.PreviousschooldetailsId == b.PreviousschooldetailsId);

                        var SiblingInfoToRemove = existingEntity.SiblingInfos
                                                .Where(existingSiblingInfos => entity.SiblingInfos.Any(d => d.FormId == existingSiblingInfos.FormId))
                                                .ToList();

                        foreach (var item in SiblingInfoToRemove)
                        {
                            context.Entry(item).State = EntityState.Deleted;
                            existingEntity.SiblingInfos.Remove(item);
                        }
                        UpdateSiblingEntities(existingEntity.SiblingInfos, entity.SiblingInfos, (a, b) => a.SiblingId == b.SiblingId);
                        UpdateChildEntities(existingEntity.StudentHealthInfoDetails, entity.StudentHealthInfoDetails, (a, b) => a.StudenthealthinfodetailsId == b.StudenthealthinfodetailsId);
                        UpdateChildEntities(existingEntity.StudentIllnessDetails, entity.StudentIllnessDetails, (a, b) => a.StudentillnessdetailsId == b.StudentillnessdetailsId);
                        UpdateChildEntities(existingEntity.StudentInfoDetails, entity.StudentInfoDetails, (a, b) => a.StudentinfoId == b.StudentinfoId);
                        UpdateChildEntities(existingEntity.TransportDetails, entity.TransportDetails, (a, b) => a.TransportdetailsId == b.TransportdetailsId);
                    }
                }
                else
                {
                    await base.InsertOrUpdate(entity);
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the specific exception
                return false;
            }
        }

        private void UpdateChildEntities<T>(ICollection<T> existingCollection, ICollection<T> updatedCollection, Func<T, T, bool> areEqual)
    where T : class
        {
            // Delete functionality
            var itemsToRemove = existingCollection
                .Where(existingItem => !updatedCollection.Any(updatedItem => areEqual(existingItem, updatedItem)))
                .ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                context.Entry(itemToRemove).State = EntityState.Deleted;
                existingCollection.Remove(itemToRemove);
            }

            // Update and add new
            foreach (var updatedItem in updatedCollection)
            {
                var existingItem = existingCollection.FirstOrDefault(e => areEqual(e, updatedItem));

                if (existingItem != null)
                {
                    context.Entry(existingItem).CurrentValues.SetValues(updatedItem);
                }
                else
                {
                    existingCollection.Add(updatedItem);
                    context.Entry(updatedItem).State = EntityState.Added;
                }
            }
        }

        private void UpdateSiblingEntities<T>(ICollection<T> existingCollection, ICollection<T> updatedCollection, Func<T, T, bool> areEqual)
   where T : class
        {
            // add new
            foreach (var updatedItem in updatedCollection)
            {
                existingCollection.Add(updatedItem);
                context.Entry(updatedItem).State = EntityState.Added;
            }
        }
        public override async Task<AdmissionForm?> GetById(int id)
        {
            try
            {
                return getbyID(id, null);
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

        public async Task<(List<AdmissionForm>, int)> GetAll(PaginationFilter paginationFilter)
        {
            int minStatusCode = 3;
            int maxStatusCode = 100;

            int pageNumber = paginationFilter.PageNumber;
            int pageSize = paginationFilter.PageSize;
            int? statusCode = paginationFilter.StatusCode;
            string name = paginationFilter.Name ?? string.Empty;
            int? academicId = paginationFilter.academic_id;
            int? gradeId = paginationFilter.grade_id;
            int? streamId = paginationFilter.stream_id;

            IQueryable<AdmissionForm> query = dbSet
                .Include(a => a.StudentInfoDetails).AsQueryable();
                //.Include(a => a.AdmissionDocuments)
                //.Include(a => a.AdmissionEnquiryDetails)
                //.Include(a => a.SiblingInfos)
                //.Include(a => a.StudentHealthInfoDetails)
                //.Include(a => a.FamilyOrGuardianInfoDetails)
                //.Include(a => a.PreviousSchoolDetails)
                //.Include(a => a.EmergencyContactDetails)
                //.Include(a => a.TransportDetails)
                //.Include(a => a.StudentIllnessDetails).AsQueryable();

            // Apply status code filter
            if (statusCode != null)
            {
                query = query.Where(a => a.AdmissionStatus == statusCode);
            }
            else
            {
                query = query.Where(a => a.AdmissionStatus >= minStatusCode && a.AdmissionStatus <= maxStatusCode);
            }

            // Apply name filter
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.StudentInfoDetails.Any(o => o.FirstName.Contains(name)));
            }

            // Apply academic ID filter
            if (academicId != null)
            {
                query = query.Where(a => a.AcademicId == academicId);
            }

            // Apply grade ID filter
            if (gradeId != null)
            {
                query = query.Where(a => a.GradeId == gradeId);
            }

            // Apply stream ID filter
            if (streamId != null)
            {
                query = query.Where(a => a.StreamId == streamId);
            }

            // Get total count of records that match the filters
            int totalRecords = await query.CountAsync();

            // Retrieve paged data with specified filters and order by FormId in descending order
            List<AdmissionForm> pagedData = await query
                .OrderByDescending(a => a.FormId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

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
                    if(!userWise)
                    {
                        dbSet.Entry(admissionForm).Collection(adm => adm.AdmissionDocuments).Load();
                    }
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

        public AdmissionForm UpdateApplicationStatus(AdmissionFormStatusDto admissionFormStatusDto)
        {
            try
            {
                var exist = getbyID(admissionFormStatusDto.FormId, null);
                AdmissionForm admission = exist;
                if (exist != null)
                {
                    if(admissionFormStatusDto.StatusId==5)
                    {
                        admission.EntranceScheduleDate = admissionFormStatusDto.EntranceScheduleDate;

                    }
                    else if(admissionFormStatusDto.StatusId==6)
                    {
                        admission.ScheduledDate = admissionFormStatusDto.ScheduleDate;
                       
                    }

                    admission.AdmissionStatus = admissionFormStatusDto.StatusId;
                    admission.Comments = admissionFormStatusDto.Comments;

                    context.Entry(exist).CurrentValues.SetValues(admission);
                    return admission;
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return null;
        }

        #endregion
    }
}
