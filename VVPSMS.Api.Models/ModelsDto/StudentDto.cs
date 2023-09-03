using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        public string StudentUsername { get; set; } = null!;

        public string StudentPassword { get; set; } = null!;

        public string StudentGivenName { get; set; } = null!;

        public string StudentSurname { get; set; } = null!;

        public string? StudentPhone { get; set; }

        public string? StudentRole { get; set; }

        public string StudentLoginType { get; set; } = null!;

        public int Enforce2Fa { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? LastloginAt { get; set; }
        public List<DocumentDto>? Documents { get; set; }
    }

}
