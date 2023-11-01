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

        public void createDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                // Delete the files
                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                    fileInfo.Delete();
            }
            else
                Directory.CreateDirectory(directory);
        }
        public async void RemoveRangeofDocuments(int formid)
        {
            try
            {
                var admissionFormdocuments = dbSet.Where(x => x.FormId == formid).ToList();

                if (admissionFormdocuments.Count > 0)
                {
                    foreach (var document in admissionFormdocuments)
                    {
                        createDirectory(document.DocumentPath);
                    }
                    await base.RemoveRange(admissionFormdocuments);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public override async Task<List<AdmissionDocument>> GetAll(int id)
        {
            try
            {
                return dbSet.Where(x => x.FormId == id).ToList();
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// RemoveRangeofDetails
        /// </summary>
        public async void RemoveRangeofDetails()
        {
            try
            {
                var admissionDocuments = dbSet.Where(x => x.FormId == null).ToList();

                if (admissionDocuments.Count > 0)
                {
                    base.RemoveRange(admissionDocuments);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
