using AutoMapper;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Students;

namespace VVPSMS.Service.DataManagers.StudentDataManagers
{
    public class StudentUnitOfWork : IStudentUnitOfWork
    {
        private readonly VvpsmsdbContext vvpsmsdbContext;
        private readonly IMapper mapper;
        public IStudentService StudentService { get; private set; }

        public IStudentDocumentService DocumentService { get; private set; }

        public StudentUnitOfWork(VvpsmsdbContext vvpsmsdbContext, IMapper mapper)
        {
            this.vvpsmsdbContext = vvpsmsdbContext;
            this.mapper = mapper;
            DocumentService = new StudentDocumentService(vvpsmsdbContext);
            StudentService = new StudentService(vvpsmsdbContext);
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
