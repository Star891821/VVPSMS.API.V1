using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.Linq;
using VVPSMS.Domain.Models;
using VVPSMS.Service.DataManagers.AdmissionDataManagers;
using VVPSMS.Service.Repository.Admissions;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.Service.DataManagers.DraftAdmissionDataManagers
{
    /// <summary>
    /// AdmissionService
    /// </summary>
    public class DraftAdmissionService : GenericService<ArAdmissionForm>, IDraftAdmissionService
    {
        #region Declarations
        protected VvpsmsdbContext context;
        #endregion
        #region public methods
        public DraftAdmissionService(VvpsmsdbContext context) : base(context)
        {
            this.context = context;
        }
        
        public override async Task<bool> InsertOrUpdate(ArAdmissionForm entity)
        {
            try
            {
                var exist = getbyID(entity.ArformId, null);


                if (exist != null)
                {
                    ArAdmissionForm existingEntity = context.Set<ArAdmissionForm>().Local.FirstOrDefault(e => e.ArformId == entity.ArformId);

                    if (existingEntity == null)
                    {
                        context.Entry(entity).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(existingEntity).CurrentValues.SetValues(entity);

                        UpdateChildEntities(existingEntity.ArAdmissionDocuments, entity.ArAdmissionDocuments, (a, b) => a.ArdocumentId == b.ArdocumentId);
                        UpdateChildEntities(existingEntity.ArAdmissionEnquiryDetails, entity.ArAdmissionEnquiryDetails, (a, b) => a.AradmissionenquirydetailsId == b.AradmissionenquirydetailsId);
                        UpdateChildEntities(existingEntity.ArEmergencyContactDetails, entity.ArEmergencyContactDetails, (a, b) => a.AremergencycontactdetailsId == b.AremergencycontactdetailsId);
                        UpdateChildEntities(existingEntity.ArFamilyOrGuardianInfoDetails, entity.ArFamilyOrGuardianInfoDetails, (a, b) => a.ArfamilyorguardianinfodetailsId == b.ArfamilyorguardianinfodetailsId);
                        UpdateChildEntities(existingEntity.ArPreviousSchoolDetails, entity.ArPreviousSchoolDetails, (a, b) => a.ArpreviousschooldetailsId == b.ArpreviousschooldetailsId);

                        var ArSiblingInfoToRemove = existingEntity.ArSiblingInfos
                                                .Where(existingSiblingInfos => entity.ArSiblingInfos.Any(d => d.ArformId == existingSiblingInfos.ArformId))
                                                .ToList();

                        foreach (var item in ArSiblingInfoToRemove)
                        {
                            context.Entry(item).State = EntityState.Deleted;
                            existingEntity.ArSiblingInfos.Remove(item);
                        }

                        UpdateSiblingEntities(existingEntity.ArSiblingInfos, entity.ArSiblingInfos, (a, b) => a.ArsiblingId == b.ArsiblingId);
                        
                        UpdateChildEntities(existingEntity.ArStudentHealthInfoDetails, entity.ArStudentHealthInfoDetails, (a, b) => a.ArstudenthealthinfodetailsId == b.ArstudenthealthinfodetailsId);
                        UpdateChildEntities(existingEntity.ArStudentIllnessDetails, entity.ArStudentIllnessDetails, (a, b) => a.ArstudentillnessdetailsId == b.ArstudentillnessdetailsId);
                        UpdateChildEntities(existingEntity.ArStudentInfoDetails, entity.ArStudentInfoDetails, (a, b) => a.ArstudentinfoId == b.ArstudentinfoId);
                        UpdateChildEntities(existingEntity.ArTransportDetails, entity.ArTransportDetails, (a, b) => a.ArtransportdetailsId == b.ArtransportdetailsId);
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
        public override async Task<ArAdmissionForm?> GetById(int id)
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
     
        public ArAdmissionForm getbyID(int? id, int? UserId, bool userWise = false)
        {
            var aradmissionForm = new ArAdmissionForm();
            try
            {
                if (userWise)
                {
                    aradmissionForm = dbSet.Where(x => x.CreatedBy == UserId && x.ArformId == id).FirstOrDefault();
                }
                else
                {
                    aradmissionForm = dbSet.Where(x => x.ArformId == id).FirstOrDefault();
                }
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
                   // dbSet.Entry(aradmissionForm).State = EntityState.Detached;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return aradmissionForm;
        }

        public List<ArAdmissionForm> getDraftAdmissionsbyID(int? UserId)
        {
            var listOfAradmissionForm = new List<ArAdmissionForm>();
            try
            {
                listOfAradmissionForm = dbSet.Where(x => x.CreatedBy == UserId).ToList();

                foreach (var item in listOfAradmissionForm)
                {
                    dbSet.Entry(item).Collection(adm => adm.ArStudentInfoDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.ArAdmissionDocuments).Load();
                    dbSet.Entry(item).Collection(adm => adm.ArAdmissionEnquiryDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.ArSiblingInfos).Load();
                    dbSet.Entry(item).Collection(adm => adm.ArStudentHealthInfoDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.ArFamilyOrGuardianInfoDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.ArPreviousSchoolDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.ArEmergencyContactDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.ArTransportDetails).Load();
                    dbSet.Entry(item).Collection(adm => adm.ArStudentIllnessDetails).Load();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfAradmissionForm;
        }



        public async Task<List<ArAdmissionForm>> GetDraftAdmissionDetailsByUserId(int userId)
        {

            try
            {
                return getDraftAdmissionsbyID(userId);
            }
            catch
            {
                return null;
            }
        }

        public async Task<ArAdmissionForm> GetDraftAdmissionDetailsByUserIdAndDraftformId(int id, int UserId)
        {

            try
            {
                return getbyID(id, UserId,true);
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
