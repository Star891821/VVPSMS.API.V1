﻿using System;
using System.Collections.Generic;

namespace VVPSMS.API.Models;

public partial class ParentDocument
{
    public int DocumentId { get; set; }

    public int ParentId { get; set; }

    public string DocumentName { get; set; } = null!;

    public string DocumentPath { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual Parent Parent { get; set; } = null!;
}
