using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class MstDocumentType
{
    public int MstdocumenttypesId { get; set; }

    public string? MstdocumenttypesDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<AdmissionDocument> AdmissionDocuments { get; set; } = new List<AdmissionDocument>();
}
