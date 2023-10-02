﻿using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    /// <summary>
    /// PreviousSchoolDetailsService
    /// </summary>
    public class PreviousSchoolDetailsService : GenericService<PreviousSchoolDetail>, IPreviousSchoolDetails
    {
        /// <summary>
        /// PreviousSchoolDetailsService
        /// </summary>
        /// <param name="context"></param>
        public PreviousSchoolDetailsService(VvpsmsdbContext context) : base(context)
        {
        }
        #region public methods
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
        #endregion

    }
}
