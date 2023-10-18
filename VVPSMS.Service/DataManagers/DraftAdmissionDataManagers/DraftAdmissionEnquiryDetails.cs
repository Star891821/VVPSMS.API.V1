using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.Service.DataManagers.DraftAdmissionDataManagers
{
    /// <summary>
    /// AdmissionEnquiryDetails
    /// </summary>
    public class DraftAdmissionEnquiryDetails : GenericService<ArAdmissionEnquiryDetail>, IDraftAdmissionEnquiryDetails
    {
        /// <summary>
        /// AdmissionEnquiryDetails
        /// </summary>
        /// <param name="context"></param>
        public DraftAdmissionEnquiryDetails(VvpsmsdbContext context) : base(context)
        {
        }
        #region public methods
        /// <summary>
        /// RemoveRangeofDetails
        /// </summary>
        public async void RemoveRangeofDetails()
        {
            try
            {
                var admissionEnquiryDetails = dbSet.Where(x => x.ArformId == null).ToList();

                if (admissionEnquiryDetails.Count > 0)
                {
                    base.RemoveRange(admissionEnquiryDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// RemoveRangeofDetails
        /// </summary>
        public async void RemoveRangeofDetailsById(int id)
        {
            try
            {
                var admissionEnquiryDetails = dbSet.Where(x => x.ArformId == id).ToList();

                if (admissionEnquiryDetails.Count > 0)
                {
                    base.RemoveRange(admissionEnquiryDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

    }
}
