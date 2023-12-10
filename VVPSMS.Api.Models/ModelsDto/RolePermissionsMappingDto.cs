
namespace VVPSMS.Api.Models.ModelsDto
{
    public class RolePermissionsMappingDto
    {
        public int MappingId { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public int ActiveYn { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
