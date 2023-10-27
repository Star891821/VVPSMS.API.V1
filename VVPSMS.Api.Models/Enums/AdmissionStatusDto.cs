using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.Enums
{
    public enum AdmissionStatusDto : int
    {
        
        [EnumDisplayName(DisplayName = "User Registrered")]
        User_Registrered = 0,
        [EnumDisplayName(DisplayName = "Submitted, Payment Pending")]
        Submitted_Payment_Pending = 1,
        [EnumDisplayName(DisplayName = "Active and Submitted Application")]
        Active_and_Submitted_Application = 2,
        Applied = 3,
        [EnumDisplayName(DisplayName = "Review Application")]
        Review_Application = 4,
        Scheduled = 5,
        [EnumDisplayName(DisplayName = "Schedule Interview")]
        Schedule_Interview = 6,
        [EnumDisplayName(DisplayName = "Confirm Admission")]
        Confirm_Admission = 7,
        [EnumDisplayName(DisplayName = "Rejected or Cancelled")]
        Rejected_or_Cancelled = 100
    }
}
