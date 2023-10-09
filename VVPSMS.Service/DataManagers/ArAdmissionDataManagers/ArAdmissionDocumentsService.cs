using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.ArAdmissionDataManagers
{
    public class ArAdmissionDocumentsService : GenericService<ArAdmissionDocument>, IArAdmissionDocumentService
    {
        public ArAdmissionDocumentsService(VvpsmsdbContext context) : base(context) { }

        public void createDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                // Delete the files
                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                    fileInfo.Delete();
                // Delete the directories here if you need to.
                directoryInfo.Delete();
            }
            else
                Directory.CreateDirectory(directory);
        }
        public async void RemoveRangeofDocuments(int formid)
        {
            try
            {
                var aradmissionFormdocuments = dbSet.Where(x => x.ArformId == formid).ToList();

                if (aradmissionFormdocuments.Count > 0)
                {
                    foreach (var document in aradmissionFormdocuments)
                    {
                        createDirectory(document.DocumentPath);
                    }
                    await base.RemoveRange(aradmissionFormdocuments);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// RemoveRangeofDetails
        /// </summary>
        public async void RemoveRangeofDetails()
        {
            try
            {
                var aradmissionDocuments = dbSet.Where(x => x.ArformId == null).ToList();

                if (aradmissionDocuments.Count > 0)
                {
                    base.RemoveRange(aradmissionDocuments);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
