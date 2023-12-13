using System.ComponentModel.DataAnnotations;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class AdmissionFormStatusDto
    {
        public int? FormId { get; set; }

        public int? StatusId { get; set; }

        public DateTime? ScheduleDate { get; set; }

        public string? Comments { get; set; }
    }
}
