using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.ArAdmissionDataManagers
{
    /// <summary>
    /// PreviousSchoolDetailsService
    /// </summary>
    public class ArPreviousSchoolDetailsService : GenericService<ArPreviousSchoolDetail>, IArPreviousSchoolDetails
    {
        /// <summary>
        /// PreviousSchoolDetailsService
        /// </summary>
        /// <param name="context"></param>
        public ArPreviousSchoolDetailsService(VvpsmsdbContext context) : base(context)
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
