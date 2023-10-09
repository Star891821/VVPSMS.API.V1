﻿using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.ArAdmissionDataManagers
{
    /// <summary>
    /// StudentHealthInfoDetails
    /// </summary>
    public class ArStudentHealthInfoDetails : GenericService<ArStudentHealthInfoDetail>, IArStudentHealthInfoDetails
    {
        /// <summary>
        /// StudentHealthInfoDetails
        /// </summary>
        /// <param name="context"></param>
        public ArStudentHealthInfoDetails(VvpsmsdbContext context) : base(context)
        {
        }
        #region public method
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
            var studentHealthInfoDetails = dbSet.Where(x => x.ArformId == id).ToList();

            if (studentHealthInfoDetails.Count > 0)
            {
                base.RemoveRange(studentHealthInfoDetails);
            }
        }
        #endregion
    }
}
