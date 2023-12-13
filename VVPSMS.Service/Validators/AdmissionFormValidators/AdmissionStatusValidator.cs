using FluentValidation;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Validators.AdmissionFormValidators
{
    public class AdmissionStatusValidator : AbstractValidator<AdmissionFormStatusDto>
    {
        private bool BeAValidDate(DateTime? date)
        {
            return !date.Equals(default);
        }
        public AdmissionStatusValidator()
        {
            RuleFor(p => p.ScheduleDate).NotEmpty().WithErrorCode("ScheduleDate").WithMessage("ScheduleDate cannot be Empty")
               .Must(BeAValidDate).WithErrorCode("ScheduleDate").WithMessage("ScheduleDate should be valid date");
        }
    }
}
