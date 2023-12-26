using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class ApplicantResponseDto
    {
        public int ApplicantId { get; set; }

        public string Applicantname { get; set; } 

        public string Applicantpassword { get; set; } 

        public string ApplicantGivenName { get; set; }

        public string ApplicantSurname { get; set; }

        public string? ApplicantPhone { get; set; }

        public int RoleId { get; set; }

        public string ApplicantLoginType { get; set; } 

        public int Enforce2Fa { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? LastloginAt { get; set; }

        public string? Applicantemail { get; set; }

    }
}
