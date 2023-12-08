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
    public class FamilyOrGuardianInfoDetailsValidator : AbstractValidator<FamilyOrGuardianInfoDetailDto>
    {
        readonly Regex onlyAlphabet = new Regex("^\\D+$");
        readonly Regex AlphaNumeric = new Regex("^[0-9a-zA-Z\" \"''-_@#/]+$");
        readonly Regex onlyNumbers = new Regex("^[0-9]*$");
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default);
        }
        private bool BeAValidDate(DateTime? date)
        {
            return !date.Equals(default);
        }
        public FamilyOrGuardianInfoDetailsValidator()
        {
            RuleFor(p => p.FormId).NotNull()
                .WithErrorCode("FormId")
                .WithMessage("FormId cannot be null");
            RuleFor(p => p.Name).NotEmpty().WithErrorCode("Name").WithMessage("Name cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("Name").WithMessage("Name should contains only Alphabets");

            RuleFor(p => p.Dob).NotEmpty().WithErrorCode("Dob").WithMessage("Dob cannot be Empty")
                .Must(BeAValidDate).WithErrorCode("Dob").WithMessage("Dob should be valid date")
                .LessThan(p => DateTime.Now).WithErrorCode("Dob").WithMessage("Dob should be less than current date");

            RuleFor(p => p.HighestQualification).NotEmpty().WithErrorCode("HighestQualification").WithMessage("HighestQualification cannot be Empty")
                           .Matches(onlyAlphabet).WithErrorCode("HighestQualification").WithMessage("HighestQualification should contains only Alphabets");
            RuleFor(p => p.Occupation).NotEmpty().WithErrorCode("Occupation").WithMessage("Occupation cannot be Empty")
                           .Matches(onlyAlphabet).WithErrorCode("Occupation").WithMessage("Occupation should contains only Alphabets");
            RuleFor(p => p.DesignationNameofcompany).NotEmpty().WithErrorCode("DesignationNameofcompany").WithMessage("DesignationNameofcompany cannot be Empty")
                           .Matches(onlyAlphabet).WithErrorCode("DesignationNameofcompany").WithMessage("DesignationNameofcompany should contains only Alphabets");

            RuleFor(p => p.AnnualIncome).NotNull().WithErrorCode("AnnualIncome").WithMessage("AnnualIncome cannot be null")
                          .GreaterThan(0).WithErrorCode("AnnualIncome").WithMessage("AnnualIncome must be greater than 0.");

            //RuleFor(p => p.OfficeAddress).Matches(AlphaNumeric)
            //      .When(x => !string.IsNullOrEmpty(x.OfficeAddress)).WithErrorCode("OfficeAddress").WithMessage("OfficeAddress should contains only Alpha Numeric Characters");

            RuleFor(p => p.AadharNumber).Matches(onlyNumbers).WithErrorCode("AadharNumber").WithMessage("AadharNumber should contains only Numeric Characters");

            RuleFor(p => p.PanNumber).Matches(AlphaNumeric).WithErrorCode("PanNumber").WithMessage("PanNumber should contains only Alpha Numeric Characters");


            RuleFor(p => p.Passportnumber).Matches(AlphaNumeric)
                .When(x => !string.IsNullOrEmpty(x.Passportnumber)).WithErrorCode("Passportnumber").WithMessage("Passportnumber should contains only Alpha Numeric Characters");


            RuleFor(p => p.Passportissuedate).Must(BeAValidDate)
                 .When(x => x.Passportissuedate.HasValue).WithErrorCode("Passportissuedate").WithMessage("DateOfIssue should be valid date")
              .LessThan(p => p.Passportexpirydate).WithErrorCode("Passportissuedate").WithMessage("Passportissuedate should be less than Passportexpirydate");

            RuleFor(p => p.Passportexpirydate).Must(BeAValidDate)
                 .When(x => x.Passportexpirydate.HasValue).WithErrorCode("Passportexpirydate").WithMessage("Passportexpirydate should be valid date")
              .GreaterThan(p => p.Passportissuedate).WithErrorCode("Passportissuedate").WithMessage("Passportexpirydate should be greater than Passportissuedate");

            RuleFor(p => p.Contact)
             .Cascade(CascadeMode.Stop)
             .Must(PhoneNumberValidation)
             .When(p => !string.IsNullOrWhiteSpace(p.Contact))
             .WithMessage("Family Or Guardian Info Details: Invalid Phone Number Format.");

            //RuleFor(p => p.Contact).NotNull().WithErrorCode("Contact").WithMessage("Contact cannot be null")
            //    .Matches(onlyNumbers).WithErrorCode("Contact").WithMessage("Contact should contains only Numeric Characters");


            RuleFor(p => p.Email).NotNull().WithErrorCode("Email").WithMessage("Email cannot be null")
                .EmailAddress().WithErrorCode("Email").WithMessage("A valid email is required");

            RuleFor(p => p.Preferredcontact).Matches(onlyAlphabet)
                 .When(x => !string.IsNullOrEmpty(x.Preferredcontact)).WithErrorCode("Preferredcontact").WithMessage("Preferredcontact should contains only Alphabets");

        }

        private bool PhoneNumberValidation(string? Contact)
        {
            // Custom logic to validate phone number
            return Contact != null && !Contact.All(c => c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9');
        }
    }
}
