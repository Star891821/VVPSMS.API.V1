using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.Service.DataManagers.DraftAdmissionDataManagers
{
    /// <summary>
    /// EmergencyContactDetailsService
    /// </summary>
    public class DraftEmergencyContactDetailsService : GenericService<ArEmergencyContactDetail>, IDraftEmergencyContactDetails
    {
        /// <summary>
        /// EmergencyContactDetailsService
        /// </summary>
        /// <param name="context"></param>
        public DraftEmergencyContactDetailsService(VvpsmsdbContext context) : base(context)
        {
        }
        #region public methods
        /// <summary>
        /// RemoveRangeofDetails
        /// </summary>
        public async void RemoveRangeofDetails()
        {
            var emergencyContactDetails = dbSet.Where(x => x.ArformId == null).ToList();

            if (emergencyContactDetails.Count > 0)
            {
                base.RemoveRange(emergencyContactDetails);
            }
        }

        /// <summary>
        /// RemoveRangeofDetails by id
        /// </summary>
        public async void RemoveRangeofDetailsById(int id)
        {
            var emergencyContactDetails = dbSet.Where(x => x.ArformId == id).ToList();

            if (emergencyContactDetails.Count > 0)
            {
                base.RemoveRange(emergencyContactDetails);
            }
        }
        #endregion

    }
}
