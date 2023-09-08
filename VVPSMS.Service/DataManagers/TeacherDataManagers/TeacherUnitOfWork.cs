using AutoMapper;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Teachers;

namespace VVPSMS.Service.DataManagers.TeacherDataManagers
{
    public class TeacherUnitOfWork : ITeacherUnitOfWork
    {
        private readonly VvpsmsdbContext vvpsmsdbContext;
        private readonly IMapper mapper;
        public ITeacherService TeacherService { get; private set; }

        public ITeacherDocumentService DocumentService { get; private set; }

        public TeacherUnitOfWork(VvpsmsdbContext vvpsmsdbContext, IMapper mapper)
        {
            this.vvpsmsdbContext = vvpsmsdbContext;
            this.mapper = mapper;
            DocumentService = new TeacherDocumentService(vvpsmsdbContext);
            TeacherService = new TeacherService(vvpsmsdbContext);
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
