﻿using System;
using System.Collections.Generic;

namespace VVPSMS.API.Models;

public partial class MstSchoolStream
{
    public int StreamId { get; set; }

    public string StreamName { get; set; } = null!;

    public int ActiveYn { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }
}
