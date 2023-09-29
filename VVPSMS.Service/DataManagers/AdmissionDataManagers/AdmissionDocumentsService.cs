using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    public class AdmissionDocumentsService : GenericService<AdmissionDocument>, IAdmissionDocumentService
    {
        public AdmissionDocumentsService(VvpsmsdbContext context) : base(context) { }

        public async void RemoveRangeofDocuments(int formid)
        {
            var admissionFormdocuments =  dbSet.Where(x => x.FormId == formid).ToList();

            if (admissionFormdocuments.Count > 0)
            {
                base.RemoveRange(admissionFormdocuments);
            }
        }

    }
}
