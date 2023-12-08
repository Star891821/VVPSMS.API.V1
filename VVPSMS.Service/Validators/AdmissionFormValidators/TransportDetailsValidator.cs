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
    public class TransportDetailsValidator : AbstractValidator<TransportDetailDto>
    {
        readonly Regex onlyAlphabet = new Regex("^\\D+$");

        readonly Regex AlphaNumeric = new Regex("^[0-9a-zA-Z\" \"''-_@#/]+$");
        readonly Regex onlyNumbers = new Regex("^[0-9]*$");
        private bool BeAValidDate(DateTime? date)
        {
            return !date.Equals(default);
        }
        public TransportDetailsValidator()
        {
            RuleFor(p => p.FormId).NotNull().WithErrorCode("FormId").WithMessage("FormId cannot be null");
            RuleFor(p => p.Academicid).NotNull().WithErrorCode("Academicid").WithMessage("Academicid cannot be null")
                 .GreaterThan(0).WithErrorCode("Academicid").WithMessage("Academicid should be greater than 0");


            RuleFor(p => p.NameofStudent).Matches(onlyAlphabet).WithErrorCode("NameofStudent").WithMessage("NameofStudent should contains only Alphabets");

            RuleFor(p => p.FatherName).Matches(onlyAlphabet).WithErrorCode("FatherName").WithMessage("FatherName should contains only Alphabets");

            RuleFor(p => p.MotherName).Matches(onlyAlphabet).WithErrorCode("MotherName").WithMessage("MotherName should contains only Alphabets");

            
            RuleFor(p => p.DateofApplication).Must(BeAValidDate).WithErrorCode("DateofApplication").WithMessage("DateofApplication should be valid date");


            RuleFor(p => p.AdmittedTo).Matches(AlphaNumeric).WithErrorCode("AdmittedTo").WithMessage("AdmittedTo should contains Alpha Numeric Characters");

            RuleFor(p => p.LandMark).Matches(AlphaNumeric).WithErrorCode("LandMark").WithMessage("LandMark should contains Alpha Numeric Characters");

            RuleFor(p => p.PreferredPickupPoint).Matches(AlphaNumeric).WithErrorCode("PreferredPickupPoint").WithMessage("PreferredPickupPoint should contains Alpha Numeric Characters");

            RuleFor(p => p.PreferredDropPoint).Matches(AlphaNumeric).WithErrorCode("PreferredDropPoint").WithMessage("PreferredDropPoint should contains Alpha Numeric Characters");
            RuleFor(p => p.FatherEmail).Matches(AlphaNumeric).WithErrorCode("FatherEmail").WithMessage("FatherEmail should contains Alpha Numeric Characters");

            RuleFor(p => p.MotherEmail).Matches(AlphaNumeric).WithErrorCode("MotherEmail").WithMessage("MotherEmail should contains Alpha Numeric Characters");


            //RuleFor(p => p.Address).Matches(AlphaNumeric).WithErrorCode("Address").WithMessage("Address should contains Alpha Numeric Characters");

            //RuleFor(p => p.FatherPhone).Matches(onlyNumbers).WithErrorCode("FatherPhone").WithMessage("FatherPhone should contains only Numbers");

            //RuleFor(p => p.MotherPhone).Matches(onlyNumbers).WithErrorCode("MotherPhone").WithMessage("MotherPhone should contains only Numbers");

            RuleFor(p => p.FatherPhone)
            .Cascade(CascadeMode.Stop)
            .Must(PhoneNumberValidation)
            .When(p => !string.IsNullOrWhiteSpace(p.FatherPhone))
            .WithMessage("Invalid Father Phone Number Format.");

            RuleFor(p => p.MotherPhone)
            .Cascade(CascadeMode.Stop)
            .Must(PhoneNumberValidation)
            .When(p => !string.IsNullOrWhiteSpace(p.MotherPhone))
            .WithMessage("Invalid Mother Phone Number Format.");
        }

        private bool PhoneNumberValidation(string? Contact)
        {
            // Custom logic to validate phone number
            return Contact != null && !Contact.All(c => c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9');
        }
    }
}
