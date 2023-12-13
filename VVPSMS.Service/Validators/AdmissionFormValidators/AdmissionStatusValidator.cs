using FluentValidation;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Validators.AdmissionFormValidators
{
    public class AdmissionStatusValidator : AbstractValidator<AdmissionFormStatusDto>
    {
       
        public AdmissionStatusValidator()
        {
            RuleFor(p => p.StatusId).NotNull()
               .WithErrorCode("StatusId")
               .WithMessage("StatusId cannot be null")
               .GreaterThan(0).WithErrorCode("StatusId").WithMessage("StatusId must be greater than 0");
            RuleFor(p => p.FormId).NotNull()
               .WithErrorCode("FormId")
               .WithMessage("FormId cannot be null")
               .GreaterThan(0).WithErrorCode("FormId").WithMessage("FormId must be greater than 0");

        }
    }
}
