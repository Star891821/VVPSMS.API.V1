using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    /// <summary>
    /// AdmissionEnquiryDetails
    /// </summary>
    public class AdmissionEnquiryDetails : GenericService<AdmissionEnquiryDetail>, IAdmissionEnquiryDetails
    {
        /// <summary>
        /// AdmissionEnquiryDetails
        /// </summary>
        /// <param name="context"></param>
        public AdmissionEnquiryDetails(VvpsmsdbContext context) : base(context)
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
                var admissionFormdocuments = dbSet.Where(x => x.FormId == null).ToList();

                if (admissionFormdocuments.Count > 0)
                {
                    base.RemoveRange(admissionFormdocuments);
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
