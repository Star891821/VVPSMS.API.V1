using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IArAdmissionService : ICommonService<ArAdmissionForm>
    {
        Task<List<ArAdmissionForm>> GetArAdmissionDetailsByUserId(int id);
        Task<ArAdmissionForm> GetArAdmissionDetailsByUserIdAndArformId(int id,int UserId);
    }
}
