namespace VVPSMS.Service.Repository.Parents
{
    public interface IParentUnitOfWork : IDisposable
    {
        IParentDocumentService DocumentService { get; }
        IParentService ParentService { get; }
        Task CompleteAsync();
    }
}
