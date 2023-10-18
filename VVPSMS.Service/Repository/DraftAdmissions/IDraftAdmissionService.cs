using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository.DraftAdmissions
{
    public interface IDraftAdmissionService : ICommonService<ArAdmissionForm>
    {
        Task<List<ArAdmissionForm>> GetDraftAdmissionDetailsByUserId(int id);
        Task<ArAdmissionForm> GetDraftAdmissionDetailsByUserIdAndDraftformId(int id,int UserId);
    }
}
