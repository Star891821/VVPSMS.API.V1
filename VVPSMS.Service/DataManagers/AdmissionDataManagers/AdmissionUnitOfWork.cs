using AutoMapper;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Admissions;

namespace VVPSMS.Service.DataManagers.AdmissionDataManagers
{
    public class AdmissionUnitOfWork : IAdmissionUnitOfWork
    {
        private readonly VvpsmsdbContext vvpsmsdbContext;
        private readonly IMapper mapper;
        public IAdmissionDocumentService AdmissionDocumentService { get; private set; }
        public IAdmissionService AdmissionService { get; private set; }

        public AdmissionUnitOfWork(VvpsmsdbContext vvpsmsdbContext, IMapper mapper)
        {
            this.vvpsmsdbContext = vvpsmsdbContext;
            this.mapper = mapper;
            AdmissionDocumentService = new AdmissionDocumentsService(vvpsmsdbContext);
            AdmissionService = new AdmissionService(vvpsmsdbContext);
        }

        public void Dispose()
        {
            vvpsmsdbContext.Dispose();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await vvpsmsdbContext.SaveChangesAsync() > 0;
        }

        public Task CompleteAsync()
        {
            return vvpsmsdbContext.SaveChangesAsync();
        }
    }
}
