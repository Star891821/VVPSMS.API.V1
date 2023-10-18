using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.Service.DataManagers.DraftAdmissionDataManagers
{
    public class DraftStudentInfoDetails : GenericService<ArStudentInfoDetail>, IDraftStudentInfoDetails
    {
        public DraftStudentInfoDetails(VvpsmsdbContext context) : base(context)
        {
        }

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
            var studentInfoDetails = dbSet.Where(x => x.ArformId == id).ToList();

            if (studentInfoDetails.Count > 0)
            {
                base.RemoveRange(studentInfoDetails);
            }
        }
    }
}
