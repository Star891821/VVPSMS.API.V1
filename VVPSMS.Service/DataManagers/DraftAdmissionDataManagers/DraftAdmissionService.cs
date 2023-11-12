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
        //public override async Task<bool> InsertOrUpdate(ArAdmissionForm entity)
        //{
        //    try
        //    {
        //        var exist = getbyID(entity.ArformId, null);

        //        if (exist != null)
        //        {
        //            ArAdmissionForm existingEntity = context.Set<ArAdmissionForm>().Local.FirstOrDefault(e => e.ArformId == entity.ArformId);

        //            if (existingEntity == null)
        //            {
        //                context.Entry(entity).State = EntityState.Modified;
        //            }
        //            else
        //            {
        //                context.Entry(existingEntity).CurrentValues.SetValues(entity);

        //                #region ArAdmissionDocuments

        //                var admissionDocumentsToRemove = existingEntity.ArAdmissionDocuments
        //                    .Where(existingDocument => !entity.ArAdmissionDocuments.Any(d => d.ArdocumentId == existingDocument.ArdocumentId))
        //                    .ToList();

        //                foreach (var existingDocument in admissionDocumentsToRemove)
        //                {
        //                    // Remove the existingDocument because it's not in the updated list
        //                    context.Entry(existingDocument).State = EntityState.Deleted;
        //                    existingEntity.ArAdmissionDocuments.Remove(existingDocument);
        //                }

        //                foreach (var document in entity.ArAdmissionDocuments)
        //                {
        //                    var existingDocument = existingEntity.ArAdmissionDocuments.FirstOrDefault(d => d.ArdocumentId == document.ArdocumentId);

        //                    if (existingDocument != null)
        //                    {
        //                        context.Entry(existingDocument).CurrentValues.SetValues(document);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArAdmissionDocuments.Add(document);
        //                        context.Entry(document).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion

        //                #region ArAdmissionEnquiryDetails
        //                var admissionEnquiryDetailsToRemove = existingEntity.ArAdmissionEnquiryDetails
        //                    .Where(enquiry => !entity.ArAdmissionEnquiryDetails.Any(d => d.AradmissionenquirydetailsId == enquiry.AradmissionenquirydetailsId))
        //                    .ToList();

        //                foreach (var existingenquirydetails in admissionEnquiryDetailsToRemove)
        //                {
        //                    // Remove the existingenquirydetails because it's not in the updated list
        //                    context.Entry(existingenquirydetails).State = EntityState.Deleted;
        //                    existingEntity.ArAdmissionEnquiryDetails.Remove(existingenquirydetails);
        //                }

        //                foreach (var enquiry in entity.ArAdmissionEnquiryDetails)
        //                {
        //                    var existingenquirydetails = existingEntity.ArAdmissionEnquiryDetails.FirstOrDefault(d => d.AradmissionenquirydetailsId == enquiry.AradmissionenquirydetailsId);

        //                    if (existingenquirydetails != null)
        //                    {
        //                        context.Entry(existingenquirydetails).CurrentValues.SetValues(enquiry);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArAdmissionEnquiryDetails.Add(enquiry);
        //                        context.Entry(enquiry).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion

        //                #region ArEmergencyContactDetails

        //                // delete functionality
        //                var emergencyContactDetailsToRemove = existingEntity.ArEmergencyContactDetails
        //                    .Where(enquiry => !entity.ArEmergencyContactDetails.Any(d => d.AremergencycontactdetailsId == enquiry.AremergencycontactdetailsId))
        //                    .ToList();

        //                foreach (var existingemergencycontactdetails in emergencyContactDetailsToRemove)
        //                {
        //                    context.Entry(existingemergencycontactdetails).State = EntityState.Deleted;
        //                    existingEntity.ArEmergencyContactDetails.Remove(existingemergencycontactdetails);
        //                }

        //                // update and add new

        //                foreach (var emergency in entity.ArEmergencyContactDetails)
        //                {
        //                    var existingemergencycontactdetails = existingEntity.ArEmergencyContactDetails.FirstOrDefault(d => d.AremergencycontactdetailsId == emergency.AremergencycontactdetailsId);

        //                    if (existingemergencycontactdetails != null)
        //                    {
        //                        context.Entry(existingemergencycontactdetails).CurrentValues.SetValues(emergency);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArEmergencyContactDetails.Add(emergency);
        //                        context.Entry(emergency).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion

        //                #region ArFamilyOrGuardianInfoDetails

        //                // delete functionality
        //                var familyOrGuardianInfoDetailsToRemove = existingEntity.ArFamilyOrGuardianInfoDetails
        //                    .Where(enquiry => !entity.ArFamilyOrGuardianInfoDetails.Any(d => d.ArfamilyorguardianinfodetailsId == enquiry.ArfamilyorguardianinfodetailsId))
        //                    .ToList();

        //                foreach (var existingfamilyOrGuardianInfoDetails in familyOrGuardianInfoDetailsToRemove)
        //                {
        //                    context.Entry(existingfamilyOrGuardianInfoDetails).State = EntityState.Deleted;
        //                    existingEntity.ArFamilyOrGuardianInfoDetails.Remove(existingfamilyOrGuardianInfoDetails);
        //                }

        //                // update and add new

        //                foreach (var details in entity.ArFamilyOrGuardianInfoDetails)
        //                {
        //                    var existingfamilyOrGuardianInfoDetails = existingEntity.ArFamilyOrGuardianInfoDetails.FirstOrDefault(d => d.ArfamilyorguardianinfodetailsId == details.ArfamilyorguardianinfodetailsId);

        //                    if (existingfamilyOrGuardianInfoDetails != null)
        //                    {
        //                        context.Entry(existingfamilyOrGuardianInfoDetails).CurrentValues.SetValues(details);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArFamilyOrGuardianInfoDetails.Add(details);
        //                        context.Entry(details).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion

        //                #region ArPreviousSchoolDetails

        //                // delete functionality
        //                var previousSchoolDetailsToRemove = existingEntity.ArPreviousSchoolDetails
        //                    .Where(enquiry => !entity.ArPreviousSchoolDetails.Any(d => d.ArpreviousschooldetailsId == enquiry.ArpreviousschooldetailsId))
        //                    .ToList();

        //                foreach (var existingpreviousSchoolDetails in previousSchoolDetailsToRemove)
        //                {
        //                    context.Entry(existingpreviousSchoolDetails).State = EntityState.Deleted;
        //                    existingEntity.ArPreviousSchoolDetails.Remove(existingpreviousSchoolDetails);
        //                }

        //                // update and add new

        //                foreach (var details in entity.ArPreviousSchoolDetails)
        //                {
        //                    var existingpreviousSchoolDetails = existingEntity.ArPreviousSchoolDetails.FirstOrDefault(d => d.ArpreviousschooldetailsId == details.ArpreviousschooldetailsId);

        //                    if (existingpreviousSchoolDetails != null)
        //                    {
        //                        context.Entry(existingpreviousSchoolDetails).CurrentValues.SetValues(details);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArPreviousSchoolDetails.Add(details);
        //                        context.Entry(details).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion

        //                #region ArSiblingInfos

        //                // delete functionality
        //                var siblingInfosToRemove = existingEntity.ArSiblingInfos
        //                    .Where(enquiry => !entity.ArSiblingInfos.Any(d => d.ArsiblingId == enquiry.ArsiblingId))
        //                    .ToList();

        //                foreach (var existingsiblingInfosDetails in siblingInfosToRemove)
        //                {
        //                    context.Entry(existingsiblingInfosDetails).State = EntityState.Deleted;
        //                    existingEntity.ArSiblingInfos.Remove(existingsiblingInfosDetails);
        //                }

        //                // update and add new

        //                foreach (var details in entity.ArSiblingInfos)
        //                {
        //                    var existingsiblingInfosDetails = existingEntity.ArSiblingInfos.FirstOrDefault(d => d.ArsiblingId == details.ArsiblingId);

        //                    if (existingsiblingInfosDetails != null)
        //                    {
        //                        context.Entry(existingsiblingInfosDetails).CurrentValues.SetValues(details);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArSiblingInfos.Add(details);
        //                        context.Entry(details).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion

        //                #region ArStudentHealthInfoDetails

        //                // delete functionality
        //                var studentHealthInfoDetailsToRemove = existingEntity.ArStudentHealthInfoDetails
        //                    .Where(enquiry => !entity.ArStudentHealthInfoDetails.Any(d => d.ArstudenthealthinfodetailsId == enquiry.ArstudenthealthinfodetailsId))
        //                    .ToList();

        //                foreach (var existingstudentHealthInfoDetails in studentHealthInfoDetailsToRemove)
        //                {
        //                    context.Entry(existingstudentHealthInfoDetails).State = EntityState.Deleted;
        //                    existingEntity.ArStudentHealthInfoDetails.Remove(existingstudentHealthInfoDetails);
        //                }

        //                // update and add new

        //                foreach (var details in entity.ArStudentHealthInfoDetails)
        //                {
        //                    var existingstudentHealthInfoDetails = existingEntity.ArStudentHealthInfoDetails.FirstOrDefault(d => d.ArstudenthealthinfodetailsId == details.ArstudenthealthinfodetailsId);

        //                    if (existingstudentHealthInfoDetails != null)
        //                    {
        //                        context.Entry(existingstudentHealthInfoDetails).CurrentValues.SetValues(details);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArStudentHealthInfoDetails.Add(details);
        //                        context.Entry(details).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion

        //                #region ArStudentIllnessDetails

        //                // delete functionality
        //                var studentIllnessDetailsToRemove = existingEntity.ArStudentIllnessDetails
        //                    .Where(enquiry => !entity.ArStudentIllnessDetails.Any(d => d.ArstudentillnessdetailsId == enquiry.ArstudentillnessdetailsId))
        //                    .ToList();

        //                foreach (var existingstudentIllnessDetails in studentIllnessDetailsToRemove)
        //                {
        //                    context.Entry(existingstudentIllnessDetails).State = EntityState.Deleted;
        //                    existingEntity.ArStudentIllnessDetails.Remove(existingstudentIllnessDetails);
        //                }

        //                // update and add new

        //                foreach (var details in entity.ArStudentIllnessDetails)
        //                {
        //                    var existingstudentIllnessDetails = existingEntity.ArStudentIllnessDetails.FirstOrDefault(d => d.ArstudentillnessdetailsId == details.ArstudentillnessdetailsId);

        //                    if (existingstudentIllnessDetails != null)
        //                    {
        //                        context.Entry(existingstudentIllnessDetails).CurrentValues.SetValues(details);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArStudentIllnessDetails.Add(details);
        //                        context.Entry(details).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion

        //                #region ArStudentInfoDetails

        //                // delete functionality
        //                var studentInfoDetailsToRemove = existingEntity.ArStudentInfoDetails
        //                    .Where(enquiry => !entity.ArStudentInfoDetails.Any(d => d.ArstudentinfoId == enquiry.ArstudentinfoId))
        //                    .ToList();

        //                foreach (var existingstudentInfoDetails in studentInfoDetailsToRemove)
        //                {
        //                    context.Entry(existingstudentInfoDetails).State = EntityState.Deleted;
        //                    existingEntity.ArStudentInfoDetails.Remove(existingstudentInfoDetails);
        //                }

        //                // update and add new

        //                foreach (var details in entity.ArStudentInfoDetails)
        //                {
        //                    var existingstudentInfoDetails = existingEntity.ArStudentInfoDetails.FirstOrDefault(d => d.ArstudentinfoId == details.ArstudentinfoId);

        //                    if (existingstudentInfoDetails != null)
        //                    {
        //                        context.Entry(existingstudentInfoDetails).CurrentValues.SetValues(details);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArStudentInfoDetails.Add(details);
        //                        context.Entry(details).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion

        //                #region ArTransportDetails

        //                // delete functionality
        //                var transportDetailsToRemove = existingEntity.ArTransportDetails
        //                    .Where(enquiry => !entity.ArTransportDetails.Any(d => d.ArtransportdetailsId == enquiry.ArtransportdetailsId))
        //                    .ToList();

        //                foreach (var existingtransportDetails in transportDetailsToRemove)
        //                {
        //                    context.Entry(existingtransportDetails).State = EntityState.Deleted;
        //                    existingEntity.ArTransportDetails.Remove(existingtransportDetails);
        //                }

        //                // update and add new

        //                foreach (var details in entity.ArTransportDetails)
        //                {
        //                    var existingtransportDetails = existingEntity.ArTransportDetails.FirstOrDefault(d => d.ArtransportdetailsId == details.ArtransportdetailsId);

        //                    if (existingtransportDetails != null)
        //                    {
        //                        context.Entry(existingtransportDetails).CurrentValues.SetValues(details);
        //                    }
        //                    else
        //                    {
        //                        existingEntity.ArTransportDetails.Add(details);
        //                        context.Entry(details).State = EntityState.Added;
        //                    }
        //                }

        //                #endregion
        //            }

        //            context.SaveChangesAsync();
        //        }
        //        else
        //        {
        //            await base.InsertOrUpdate(entity);
        //        }

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

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
                        UpdateChildEntities(existingEntity.ArSiblingInfos, entity.ArSiblingInfos, (a, b) => a.ArsiblingId == b.ArsiblingId);
                        UpdateChildEntities(existingEntity.ArStudentHealthInfoDetails, entity.ArStudentHealthInfoDetails, (a, b) => a.ArstudenthealthinfodetailsId == b.ArstudenthealthinfodetailsId);
                        UpdateChildEntities(existingEntity.ArStudentIllnessDetails, entity.ArStudentIllnessDetails, (a, b) => a.ArstudentillnessdetailsId == b.ArstudentillnessdetailsId);
                        UpdateChildEntities(existingEntity.ArStudentInfoDetails, entity.ArStudentInfoDetails, (a, b) => a.ArstudentinfoId == b.ArstudentinfoId);
                        UpdateChildEntities(existingEntity.ArTransportDetails, entity.ArTransportDetails, (a, b) => a.ArtransportdetailsId == b.ArtransportdetailsId);
                        context.SaveChangesAsync();
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
