using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class AzureBlobConfigurationDto
    {
        public int Id { get; set; }

        public string DomainName { get; set; } = null!;

        public string DomainCode { get; set; } = null!;

        public string StorageConnectionString { get; set; } = null!;

        public string BlobContainerName { get; set; } = null!;

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
