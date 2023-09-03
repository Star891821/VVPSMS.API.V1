using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }

        public string TeacherUsername { get; set; } = null!;

        public string TeacherPassword { get; set; } = null!;

        public string TeacherGivenName { get; set; } = null!;

        public string TeacherSurname { get; set; } = null!;

        public string TeacherPhone { get; set; } = null!;

        public string TeacherRole { get; set; } = null!;

        public int SchoolCode { get; set; }

        public string TeacherLoginType { get; set; } = null!;

        public int Enforce2Fa { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? LastloginAt { get; set; }

        public List<DocumentDto>? Documents { get; set; }
    }
}
