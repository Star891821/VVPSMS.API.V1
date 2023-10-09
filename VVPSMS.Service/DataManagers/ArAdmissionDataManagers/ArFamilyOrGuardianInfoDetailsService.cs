using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.ArAdmissionDataManagers
{
    /// <summary>
    /// FamilyOrGuardianInfoDetailsService
    /// </summary>
    public class ArFamilyOrGuardianInfoDetailsService : GenericService<ArFamilyOrGuardianInfoDetail>, IArFamilyOrGuardianInfoDetails
    {
        /// <summary>
        /// FamilyOrGuardianInfoDetailsService
        /// </summary>
        /// <param name="context"></param>
        public ArFamilyOrGuardianInfoDetailsService(VvpsmsdbContext context) : base(context)
        {
        }
        #region public methods
        /// <summary>
        /// RemoveRangeofDetails
        /// </summary>
        public async void RemoveRangeofDetails()
        {
            var admissionFormdocuments = dbSet.Where(x => x.ArformId == null).ToList();

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
            var familyOrGuardianInfoDetails = dbSet.Where(x => x.ArformId == id).ToList();

            if (familyOrGuardianInfoDetails.Count > 0)
            {
                base.RemoveRange(familyOrGuardianInfoDetails);
            }
        }
        #endregion
    }
}
