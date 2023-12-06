using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Validators.AdmissionFormValidators
{
    public class AdmissionStudentInfoDetailsValidator : AbstractValidator<StudentInfoDetailDto>
    {
        readonly Regex onlyAlphabet = new Regex("^\\D+$");
        readonly Regex AlphaNumeric = new Regex("^[0-9a-zA-Z\" \"''-_@#/]+$");//   //^[a-zA-Z0-9]*$
        readonly Regex onlyNumbers = new Regex("^[0-9]*$");
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default);
        }
        private bool BeAValidDate(DateTime? date)
        {
            return !date.Equals(default);
        }
        public AdmissionStudentInfoDetailsValidator()
        {
            RuleFor(p => p.FormId).NotNull().WithErrorCode("FormId").WithMessage("FormId cannot be null");
            RuleFor(p => p.FirstName).NotEmpty().WithErrorCode("FirstName").WithMessage("FirstName cannot be Empty")
               .Matches(onlyAlphabet).WithErrorCode("FirstName").WithMessage("FirstName should contains only Alphabets");
           // RuleFor(p => p.MiddleName).Matches(onlyAlphabet).WithErrorCode("MiddleName").WithMessage("MiddleName should contains only Alphabets");
            RuleFor(p => p.LastName).Matches(onlyAlphabet).WithErrorCode("LastName").WithMessage("LastName should contains only Alphabets");
            RuleFor(p => p.Dob).NotEmpty().WithErrorCode("Dob").WithMessage("Dob cannot be Empty")
                .Must(BeAValidDate).WithErrorCode("Dob").WithMessage("Dob should be valid date")
                .LessThan(p => DateTime.Now).WithErrorCode("Dob").WithMessage("Dob should be less than current date");
            RuleFor(p => p.DobInWords).NotEmpty().WithErrorCode("DobInWords").WithMessage("DobInWords cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("DobInWords").WithMessage("DobInWords should contains only Alphabets");
            RuleFor(p => p.Nationality).NotEmpty().WithErrorCode("Nationality").WithMessage("Nationality cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("Nationality").WithMessage("Nationality should contains only Alphabets");
            RuleFor(p => p.Gender).NotEmpty().WithErrorCode("Gender").WithMessage("Gender cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("Gender").WithMessage("Gender should contains only Alphabets");
            RuleFor(p => p.Religion).NotEmpty().WithErrorCode("Religion").WithMessage("Religion cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("Religion").WithMessage("Religion should contains only Alphabets");
            RuleFor(p => p.Caste).NotEmpty().WithErrorCode("Caste").WithMessage("Caste cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("Caste").WithMessage("Caste should contains only Alphabets");
            RuleFor(p => p.MotherTongue).NotEmpty().WithErrorCode("MotherTongue").WithMessage("MotherTongue cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("MotherTongue").WithMessage("MotherTongue should contains only Alphabets");
            RuleFor(p => p.NoOfFamilymembers).NotNull().WithErrorCode("NoOfFamilymembers").WithMessage("NoOfFamilymembers cannot be null")
                .GreaterThan(0).WithErrorCode("NoOfFamilymembers").WithMessage("NoOfFamilymembers must be greater than 0.");
            RuleFor(p => p.StudentLivesWith).Matches(onlyAlphabet).WithErrorCode("StudentLivesWith").WithMessage("StudentLivesWith should contains only Alphabets");

            RuleFor(p => p.PassportNumber).Matches(AlphaNumeric)
                .When(x => !string.IsNullOrEmpty(x.PassportNumber)).WithErrorCode("PassportNumber").WithMessage("PassportNumber should contains only Alpha Numeric Characters");


            RuleFor(p => p.DateOfIssue).Must(BeAValidDate)
                 .When(x => x.DateOfIssue.HasValue).WithErrorCode("DateOfIssue").WithMessage("DateOfIssue should be valid date")
              .LessThan(p => p.DateOfExpiry).WithErrorCode("DateOfIssue").WithMessage("DateOfIssue should be less than DateOfExpiry");

            RuleFor(p => p.DateOfExpiry).Must(BeAValidDate)
                .When(x => x.DateOfExpiry.HasValue).WithErrorCode("DateOfExpiry").WithMessage("DateOfExpiry should be valid date")
              .GreaterThan(p => p.DateOfIssue).WithErrorCode("DateOfExpiry").WithMessage("DateOfExpiry should be greater than DateOfIssue");

            RuleFor(p => p.OtherKnownLanguages).Matches(onlyAlphabet).WithErrorCode("OtherKnownLanguages").WithMessage("OtherKnownLanguages should contains only Alphabets");

            RuleFor(p => p.TypeofFamily).NotEmpty().WithErrorCode("TypeofFamily").WithMessage("TypeofFamily cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("TypeofFamily").WithMessage("TypeofFamily should contains only Alphabets");
            //RuleFor(p => p.PresentAddress).NotEmpty().WithErrorCode("PresentAddress").WithMessage("PresentAddress cannot be Empty")
            // .Matches(AlphaNumeric).WithErrorCode("PresentAddress").WithMessage("PresentAddress should contains Alpha Numeric Characters");

            //RuleFor(p => p.PermanentAddress).NotEmpty().WithErrorCode("PermanentAddress").WithMessage("PermanentAddress cannot be Empty")
            //    .Matches(AlphaNumeric).WithErrorCode("PermanentAddress").WithMessage("PermanentAddress should contains Alpha Numeric Characters");

        }
    }
}
