using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Validators.AdmissionFormValidators
{
    public class StudentIllnessDetailsValidator : AbstractValidator<StudentIllnessDetailDto>
    {
        public StudentIllnessDetailsValidator()
        {
            RuleFor(p => p.FormId).NotNull()
                .WithErrorCode("FormId")
                .WithMessage("FormId cannot be null");
           
        }
    }
}
