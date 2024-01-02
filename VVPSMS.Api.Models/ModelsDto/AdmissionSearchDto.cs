using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.ModelsDto
{
    public class AdmissionSearchDto
    {
        [Key]
        public int FormId { get; set; }

        public int? AcademicId { get; set; }

        public object? AdmissionStatus { get; set; }
        public int? GradeId { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? EntranceScheduleDate { get; set; }
        public int? SchoolId { get; set; }

        public int? StreamId { get; set; }
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
    