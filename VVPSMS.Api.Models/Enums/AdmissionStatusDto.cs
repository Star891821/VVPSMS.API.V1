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
        
        [EnumDisplayName(DisplayName = "Registrered")]
        Registrered = 0,
        [EnumDisplayName(DisplayName = "Submitted")]
        Submitted = 1,
        [EnumDisplayName(DisplayName = "Active")]
        Active = 2,
        Applied = 3,
        [EnumDisplayName(DisplayName = "Reviewed")]
        Reviewed = 4,
        Entrance = 5,
        [EnumDisplayName(DisplayName = "Interview")]
        Interview = 6,
        [EnumDisplayName(DisplayName = "Confirmed")]
        Confirmed = 7,
        [EnumDisplayName(DisplayName = "Rejected")]
        Rejected = 100
    }
}
