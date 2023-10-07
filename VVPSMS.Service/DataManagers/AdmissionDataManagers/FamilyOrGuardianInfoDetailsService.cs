using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    /// <summary>
    /// FamilyOrGuardianInfoDetailsService
    /// </summary>
    public class FamilyOrGuardianInfoDetailsService : GenericService<FamilyOrGuardianInfoDetail>, IFamilyOrGuardianInfoDetails
    {
        /// <summary>
        /// FamilyOrGuardianInfoDetailsService
        /// </summary>
        /// <param name="context"></param>
        public FamilyOrGuardianInfoDetailsService(VvpsmsdbContext context) : base(context)
        {
        }
        #region public methods
        /// <summary>
        /// RemoveRangeofDetails
        /// </summary>
        public async void RemoveRangeofDetails()
        {
            var admissionFormdocuments = dbSet.Where(x => x.FormId == null).ToList();

            if (admissionFormdocuments.Count > 0)
            {
                base.RemoveRange(admissionFormdocuments);
            }
        }

        /// <summary>
        /// RemoveRangeofDetails by id
        /// </summary>
        public async void RemoveRangeofDetailsById(int id)
        {
            var familyOrGuardianInfoDetails = dbSet.Where(x => x.FormId == id).ToList();

            if (familyOrGuardianInfoDetails.Count > 0)
            {
                base.RemoveRange(familyOrGuardianInfoDetails);
            }
        }
        #endregion
    }
}
