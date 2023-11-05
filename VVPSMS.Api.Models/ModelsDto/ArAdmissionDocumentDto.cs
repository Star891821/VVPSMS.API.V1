using System.Collections.ObjectModel;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class ArAdmissionDocumentDto
    {
        public int ArdocumentId { get; set; }

        public int? ArformId { get; set; }

        public int? MstdocumenttypesId { get; set; }

        public string? DocumentName { get; set; }

        public string? DocumentPath { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public string? FileContentsAsBase64 { get; set; }
    }
}
