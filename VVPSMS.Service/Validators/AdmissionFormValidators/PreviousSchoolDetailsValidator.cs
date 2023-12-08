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
    public class PreviousSchoolDetailsValidator : AbstractValidator<PreviousSchoolDetailDto>
    {
        readonly Regex onlyAlphabet = new Regex("^\\D+$");

        readonly Regex AlphaNumeric = new Regex("^[0-9a-zA-Z\" \"''-_@#/]+$");///^[a-z\d\-_\s]+$/i
        private bool BeAValidDate(DateTime? date)
        {
            return !date.Equals(default);
        }
        public PreviousSchoolDetailsValidator()
        {
            RuleFor(p => p.FormId).NotNull().WithErrorCode("FormId").WithMessage("FormId cannot be null");
            RuleFor(p => p.NameSchool).Matches(onlyAlphabet).WithErrorCode("NameSchool").WithMessage("NameSchool should contains only Alphabets");
            //RuleFor(p => p.Address).Matches(AlphaNumeric).WithErrorCode("Address").WithMessage("Address should contains Alpha Numeric Characters");
            RuleFor(p => p.Curriculum).Matches(onlyAlphabet).WithErrorCode("Curriculum").WithMessage("Curriculum should contains only Alphabets");
            RuleFor(p => p.ClassCompleted).Matches(AlphaNumeric).WithErrorCode("ClassCompleted").WithMessage("ClassCompleted should contains Alpha Numeric Characters");           
            RuleFor(p => p.YearsAttended).Matches(AlphaNumeric).WithErrorCode("YearsAttended").WithMessage("YearsAttended should contains Alpha Numeric Characters");
            RuleFor(p => p.ReasonForleaving).Matches(onlyAlphabet).WithErrorCode("ReasonForleaving").WithMessage("ReasonForleaving should contains only Alphabets");
            RuleFor(p => p.HasapplicanteverExpelledorsuspended).Matches(onlyAlphabet).WithErrorCode("HasapplicanteverExpelledorsuspended").WithMessage("HasapplicanteverExpelledorsuspended should contains only Alphabets");
            RuleFor(p => p.Reasonforsuspension).Matches(AlphaNumeric).WithErrorCode("Reasonforsuspension").WithMessage("Reasonforsuspension should contains Alpha Numeric Characters");
            RuleFor(p => p.MediumofInstruction).Matches(onlyAlphabet).WithErrorCode("MediumofInstruction").WithMessage("MediumofInstruction should contains only Alphabets");
            RuleFor(p => p.DateOfLeavingschool).Must(BeAValidDate).WithErrorCode("DateOfLeavingschool").WithMessage("DateOfLeavingschool should be valid date");

        }
    }
}
