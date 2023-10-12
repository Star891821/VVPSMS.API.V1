﻿using System;
using System.Collections.Generic;

namespace VVPSMS.Domain.Models;

public partial class ArAdmissionDocument
{
    public int ArdocumentId { get; set; }

    public int? ArformId { get; set; }

    public int? MstdocumenttypesId { get; set; }

    public string DocumentName { get; set; } = null!;

    public string DocumentPath { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ArAdmissionForm? Arform { get; set; }

    public virtual MstDocumentType? Mstdocumenttypes { get; set; }
}
