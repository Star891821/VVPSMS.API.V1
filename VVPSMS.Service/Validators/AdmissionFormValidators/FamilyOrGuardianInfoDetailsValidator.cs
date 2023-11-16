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
        readonly Regex AlphaNumeric = new Regex("^[a-zA-Z0-9]*$");
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

            RuleFor(p => p.OfficeAddress).Matches(AlphaNumeric).WithErrorCode("OfficeAddress").WithMessage("OfficeAddress should contains only Alpha Numeric Characters");

            RuleFor(p => p.AadharNumber).NotNull().WithErrorCode("AadharNumber").WithMessage("AadharNumber cannot be null")
                          .GreaterThan(0).WithErrorCode("AadharNumber").WithMessage("AadharNumber must be greater than 0.");

            RuleFor(p => p.PanNumber).Matches(AlphaNumeric).WithErrorCode("PanNumber").WithMessage("PanNumber should contains only Alpha Numeric Characters");


            RuleFor(p => p.Passportnumber).Matches(AlphaNumeric).WithErrorCode("Passportnumber").WithMessage("Passportnumber should contains only Alpha Numeric Characters");


            RuleFor(p => p.Passportissuedate).NotEmpty().WithErrorCode("Passportissuedate").WithMessage("Passportissuedate cannot be Empty")
              .Must(BeAValidDate).WithErrorCode("Passportissuedate").WithMessage("DateOfIssue should be valid date")
              .LessThan(p => p.Passportexpirydate).WithErrorCode("Passportissuedate").WithMessage("Passportissuedate should be less than Passportexpirydate");

            RuleFor(p => p.Passportexpirydate).NotEmpty().WithErrorCode("Passportexpirydate").WithMessage("Passportexpirydate cannot be Empty")
              .Must(BeAValidDate).WithErrorCode("Passportexpirydate").WithMessage("Passportexpirydate should be valid date")
              .GreaterThan(p => p.Passportissuedate).WithErrorCode("Passportissuedate").WithMessage("Passportexpirydate should be greater than Passportissuedate");


            RuleFor(p => p.Contact).NotNull().WithErrorCode("Contact").WithMessage("Contact cannot be null")
                .Matches(onlyNumbers).WithErrorCode("Contact").WithMessage("Contact should contains only Numeric Characters");


            RuleFor(p => p.Email).NotNull().WithErrorCode("Email").WithMessage("Email cannot be null")
                .EmailAddress().WithErrorCode("Email").WithMessage("A valid email is required");

            RuleFor(p => p.Preferredcontact).NotEmpty().WithErrorCode("Preferredcontact").WithMessage("Preferredcontact cannot be Empty")
                          .Matches(onlyAlphabet).WithErrorCode("Preferredcontact").WithMessage("Preferredcontact should contains only Alphabets");

        }
    }
}
