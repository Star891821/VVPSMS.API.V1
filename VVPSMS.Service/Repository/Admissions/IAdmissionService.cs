using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IAdmissionService : ICommonService<AdmissionForm>
    {
        Task<(List<AdmissionForm>,int)> GetAll(int PageNumber, int PageSize,int? StatusCode, string? name);
        Task<List<AdmissionForm>> GetAdmissionDetailsByUserId(int id);
        Task<AdmissionForm> GetAdmissionDetailsByUserIdAndFormId(int id, int UserId);
    }
}
