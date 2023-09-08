using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class ParentDto
    {
        public int ParentId { get; set; }

        public string ParentUsername { get; set; } = null!;

        public string ParentPassword { get; set; } = null!;

        public string ParentGivenName { get; set; } = null!;

        public string ParentSurname { get; set; } = null!;

        public string? ParentPhone { get; set; }

        public string? ParentRole { get; set; }

        public string ParentLoginType { get; set; } = null!;

        public int Enforce2Fa { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? LastloginAt { get; set; }

        public List<ParentDocumentDto>? Documents { get; set; }
    }
}
