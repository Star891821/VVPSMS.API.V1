﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class ParentDocumentDto
    {
        public int DocumentId { get; set; }

        public int ParentId { get; set; }

        public string DocumentName { get; set; } = null!;

        public string DocumentPath { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
