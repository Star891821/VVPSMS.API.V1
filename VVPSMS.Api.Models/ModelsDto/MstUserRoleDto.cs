
namespace VVPSMS.Api.Models.ModelsDto
{
    public class MstUserRoleDto
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } = null!;

        public int ActiveYn { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
