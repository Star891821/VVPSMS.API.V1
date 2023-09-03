using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.Shared
{
    public class StorageService: IStorageService
    {
        private readonly string ConnectionString;
        private readonly string ContainerName;
        private readonly BlobServiceClient BlobClient;
 

        public StorageService(IConfiguration config)
        {
            ConnectionString = "";//config["StorageConnectionString"];
            BlobClient = null;  //new BlobServiceClient(ConnectionString);
            ContainerName = config["BlobContainerEntryPass"];
        }

        public async Task UploadFileBlobAsync(Stream content, string path, string company, string subFolder = "")
        {
            var contClient = await GetContainerClientAsync(ContainerName);
            var blobClient = contClient.GetBlobClient(string.Format(@"{0}\Images\admission\{1}\", company, subFolder) + path);
            await blobClient.UploadAsync(content, true);
        }

        public async Task<Stream> DownloadFileBlobAsync(string path, string company, string subFolder = "")
        {
            MemoryStream ms = new MemoryStream();
            var contClient = await GetContainerClientAsync(ContainerName);
            var blobClient = contClient.GetBlobClient(string.Format(@"{0}\Images\admission\{1}\", company, subFolder) + path);
            await blobClient.DownloadToAsync(ms);
            Stream blobStream = blobClient.OpenReadAsync().Result;
            return blobStream;
        }

        public async Task<string> GetBlobPath()
        {
            var contClient = await GetContainerClientAsync(ContainerName);
            return contClient.Uri.OriginalString;
        }

        private async ValueTask<BlobContainerClient> GetContainerClientAsync(string container)
        {
            var client = BlobClient.GetBlobContainerClient(container);

            if (!await client.ExistsAsync())
            {
                throw new Exception($"Blob container '{container}' not found.");
            }

            return client;
        }
    }
}
