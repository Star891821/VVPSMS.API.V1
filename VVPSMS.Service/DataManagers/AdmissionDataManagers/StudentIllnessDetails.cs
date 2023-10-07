using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    public class StudentIllnessDetails : GenericService<StudentIllnessDetail>, IStudentIllnessDetails
    {
        public StudentIllnessDetails(VvpsmsdbContext context) : base(context)
        {
        }

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
            var studentIllnessDetails = dbSet.Where(x => x.FormId == id).ToList();

            if (studentIllnessDetails.Count > 0)
            {
                base.RemoveRange(studentIllnessDetails);
            }
        }
    }
}
