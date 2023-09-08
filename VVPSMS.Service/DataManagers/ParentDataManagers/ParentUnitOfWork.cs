using AutoMapper;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Parents;

namespace VVPSMS.Service.DataManagers.ParentDataManagers
{
    public class ParentUnitOfWork : IParentUnitOfWork
    {
        private readonly VvpsmsdbContext vvpsmsdbContext;
        private readonly IMapper mapper;
        public IParentService ParentService { get; private set; }

        public IParentDocumentService DocumentService { get; private set; }

        public ParentUnitOfWork(VvpsmsdbContext vvpsmsdbContext, IMapper mapper)
        {
            this.vvpsmsdbContext = vvpsmsdbContext;
            this.mapper = mapper;
            DocumentService = new ParentDocumentService(vvpsmsdbContext);
            ParentService = new ParentService(vvpsmsdbContext);
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
