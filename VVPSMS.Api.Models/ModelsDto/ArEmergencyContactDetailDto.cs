
namespace VVPSMS.Api.Models.ModelsDto
{
    public class ArEmergencyContactDetailDto
    {
        public int AremergencycontactdetailsId { get; set; }

        public int? ArformId { get; set; }

        public string? Name { get; set; }

        public string? ContactNumber { get; set; }

        public string? Relationship { get; set; }

        public string? NameofparentIncaseofstaffWard { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
