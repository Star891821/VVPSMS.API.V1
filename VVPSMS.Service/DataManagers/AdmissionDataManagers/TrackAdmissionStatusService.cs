using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    public class TrackAdmissionStatusService : ITrackAdmissionStatusService
    {
        protected VvpsmsdbContext context;
        internal DbSet<TrackAdmissionStatus> dbSet;

        /// <summary>
        /// TrackAdmissionStatusService
        /// </summary>
        /// <param name="context"></param>
        public TrackAdmissionStatusService(VvpsmsdbContext context) 
        {
            this.context = context;
            dbSet = context.Set<TrackAdmissionStatus>();
        }

        public  List<TrackAdmissionStatus> GetAll(int formId)
        {
            var result = dbSet.Where(x => x.FormId == formId).ToList();
            return result;
        }

        public async Task<bool> Insert(TrackAdmissionStatus entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }
    }
}
