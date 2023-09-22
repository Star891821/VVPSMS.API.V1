
namespace VVPSMS.Api.Models.ModelsDto
{
    public class EmergencyContactDetailDto
    {
        public int EmergencycontactdetailsId { get; set; }

        public int FormId { get; set; }

        public string Name { get; set; } = null!;

        public int ContactNumber { get; set; }

        public string Relationship { get; set; } = null!;

        public string? NameofparentIncaseofstaffWard { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
