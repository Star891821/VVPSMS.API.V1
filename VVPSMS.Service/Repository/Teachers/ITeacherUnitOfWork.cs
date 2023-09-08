namespace VVPSMS.Service.Repository.Teachers
{
    public interface ITeacherUnitOfWork : IDisposable
    {
        ITeacherDocumentService DocumentService { get; }
        ITeacherService TeacherService { get; }
        Task CompleteAsync();

    }
}
