using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    public class StudentHealthInfoDetails : GenericService<StudentHealthInfoDetail>, IStudentHealthInfoDetails
    {
        public StudentHealthInfoDetails(VvpsmsdbContext context) : base(context)
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
    }
}
