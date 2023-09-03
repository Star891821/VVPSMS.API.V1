namespace VVPSMS.Service.Repository
{
    public interface IStorageService
    {
        Task UploadFileBlobAsync(Stream content, string path, string company, string subFolder = "");
        Task<Stream> DownloadFileBlobAsync(string path, string company, string subFolder = "");
        Task<string> GetBlobPath();
    }
}
