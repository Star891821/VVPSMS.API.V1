using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.DraftAdmissions;

namespace VVPSMS.Service.DataManagers.DraftAdmissionDataManagers
{
    public class DraftAdmissionDocumentsService : GenericService<ArAdmissionDocument>, IDraftAdmissionDocumentService
    {
        public DraftAdmissionDocumentsService(VvpsmsdbContext context) : base(context) { }

        public override async Task<List<ArAdmissionDocument>> GetAll(int id)
        {
            try
            {
                return dbSet.Where(x => x.ArformId == id).ToList();
            }
            catch
            {
                return null;
            }
        }
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
