

namespace VVPSMS.Api.Models.ModelsDto
{
    public class ArStudentInfoDetailDto
    {
        public int ArstudentinfoId { get; set; }

        public int? ArformId { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Dob { get; set; }

        public string? DobInWords { get; set; }

        public string? Nationality { get; set; }

        public string? Gender { get; set; }

        public int? Age { get; set; }

        public string? Religion { get; set; }

        public string? Caste { get; set; }

        public string? AadharNumber { get; set; }

        public string? SatsChildNumber { get; set; }

        public string? UDiseCode { get; set; }

        public string? PassportNumber { get; set; }

        public DateTime? DateOfIssue { get; set; }

        public DateTime? DateOfExpiry { get; set; }

        public string? PermanentAddress { get; set; }

        public string? PresentAddress { get; set; }

        public string? StudentLivesWith { get; set; }

        public string? TypeofFamily { get; set; }

        public int? NoOfFamilymembers { get; set; }

        public string? MotherTongue { get; set; }

        public string? OtherKnownLanguages { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool? Ispresentaddresspermanentaddress { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
