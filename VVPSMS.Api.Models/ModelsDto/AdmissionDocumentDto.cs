using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class AdmissionDocumentDto
    {
        public int DocumentId { get; set; }
        public int? FormId { get; set; }
        public int? MstdocumenttypesId { get; set; }

        public string? DocumentName { get; set; } = null!;

        public string? DocumentPath { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public string? FileContentsAsBase64 { get; set; } = null!;
    }
}
