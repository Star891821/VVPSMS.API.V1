using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.Service.DataManagers.DraftAdmissionDataManagers
{
    /// <summary>
    /// PreviousSchoolDetailsService
    /// </summary>
    public class DraftPreviousSchoolDetailsService : GenericService<ArPreviousSchoolDetail>, IDraftPreviousSchoolDetails
    {
        /// <summary>
        /// PreviousSchoolDetailsService
        /// </summary>
        /// <param name="context"></param>
        public DraftPreviousSchoolDetailsService(VvpsmsdbContext context) : base(context)
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
            var previousSchoolDetails = dbSet.Where(x => x.ArformId == id).ToList();

            if (previousSchoolDetails.Count > 0)
            {
                base.RemoveRange(previousSchoolDetails);
            }
        }
        #endregion

    }
}
