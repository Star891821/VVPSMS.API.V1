using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    /// <summary>
    /// StudentHealthInfoDetails
    /// </summary>
    public class StudentHealthInfoDetails : GenericService<StudentHealthInfoDetail>, IStudentHealthInfoDetails
    {
        /// <summary>
        /// StudentHealthInfoDetails
        /// </summary>
        /// <param name="context"></param>
        public StudentHealthInfoDetails(VvpsmsdbContext context) : base(context)
        {
        }
        #region public method
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
            var studentHealthInfoDetails = dbSet.Where(x => x.FormId == id).ToList();

            if (studentHealthInfoDetails.Count > 0)
            {
                base.RemoveRange(studentHealthInfoDetails);
            }
        }
        #endregion
    }
}
