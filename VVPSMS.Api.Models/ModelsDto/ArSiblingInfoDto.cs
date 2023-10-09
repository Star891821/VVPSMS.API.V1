namespace VVPSMS.Api.Models.ModelsDto
{
    public class ArSiblingInfoDto
    {
        public int ArsiblingId { get; set; }

        public int ArformId { get; set; }

        public string? SiblingName { get; set; }

        public DateTime? SiblingDob { get; set; }

        public string? SiblingGender { get; set; }

        public string? SiblingSchool { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
