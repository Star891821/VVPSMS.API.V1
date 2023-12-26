using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class LoginAuthResponse
    {
        public string? JwtToken { get; set; }

        public string? ExpiryDateTime { get; set; }

        public string? LoggedInUser { get; set; }

        public int UserId { get; set; }
        public string? UserName { get; set; }

        public string? GivenName { get; set; }

        public string? SurName { get; set; }

        public string? Phone { get; set; }

        public string? Role { get; set; }
    }

    public class ApplicantAuthResponse
    {
        public string? JwtToken { get; set; }

        public string? ExpiryDateTime { get; set; }

        public int ApplicantId { get; set; }

        public string Applicantname { get; set; }

        public string Applicantpassword { get; set; }

        public string ApplicantGivenName { get; set; }

        public string ApplicantSurname { get; set; }

        public string? ApplicantPhone { get; set; }

        public int RoleId { get; set; }

        public string ApplicantLoginType { get; set; }

        public int Enforce2Fa { get; set; }


        public string? Applicantemail { get; set; }

    }
}
