using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.Service.DataManagers.DraftAdmissionDataManagers
{
    /// <summary>
    /// SiblingInfosDetailsService
    /// </summary>
    public class DraftSiblingInfosDetailsService : GenericService<ArSiblingInfo>, IDraftSiblingInfosDetails
    {
        /// <summary>
        /// SiblingInfosDetailsService
        /// </summary>
        /// <param name="context"></param>
        public DraftSiblingInfosDetailsService(VvpsmsdbContext context) : base(context)
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
            var siblingInfosdetails = dbSet.Where(x => x.ArformId == id).ToList();

            if (siblingInfosdetails.Count > 0)
            {
                base.RemoveRange(siblingInfosdetails);
            }
        }
        #endregion


    }
}
