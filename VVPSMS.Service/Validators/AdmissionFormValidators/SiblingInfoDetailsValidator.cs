using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Validators.AdmissionFormValidators
{
    public class SiblingInfoDetailsValidator : AbstractValidator<SiblingInfoDto>
    {
        readonly Regex onlyAlphabet = new Regex("^\\D+$");
        
        private bool BeAValidDate(DateTime? date)
        {
            return !date.Equals(default);
        }
        public SiblingInfoDetailsValidator()
        {
            RuleFor(p => p.FormId).NotNull().WithErrorCode("FormId").WithMessage("FormId cannot be null");
            RuleFor(p => p.SiblingName).Matches(onlyAlphabet).WithErrorCode("SiblingName").WithMessage("SiblingName should contains only Alphabets");
            RuleFor(p => p.SiblingDob).Must(BeAValidDate).WithErrorCode("SiblingDob").WithMessage("SiblingDob should be valid date")
                 .LessThan(p => DateTime.Now).WithErrorCode("SiblingDob").WithMessage("SiblingDob should be less than current date");
            RuleFor(p => p.SiblingGender).Matches(onlyAlphabet).WithErrorCode("SiblingGender").WithMessage("SiblingGender should contains only Alphabets");
            RuleFor(p => p.SiblingSchool).Matches(onlyAlphabet).WithErrorCode("SiblingSchool").WithMessage("SiblingSchool should contains only Alphabets");

        }
    }
}
