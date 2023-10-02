﻿using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    /// <summary>
    /// EmergencyContactDetailsService
    /// </summary>
    public class EmergencyContactDetailsService : GenericService<EmergencyContactDetail>, IEmergencyContactDetails
    {
        /// <summary>
        /// EmergencyContactDetailsService
        /// </summary>
        /// <param name="context"></param>
        public EmergencyContactDetailsService(VvpsmsdbContext context) : base(context)
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
