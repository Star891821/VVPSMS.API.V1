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
    public class EmergencyContactDetailsValidator : AbstractValidator<EmergencyContactDetailDto>
    {
        readonly Regex onlyAlphabet = new Regex("^\\D+$");
        readonly Regex onlyNumbers = new Regex("^[0-9]*$");
       
        public EmergencyContactDetailsValidator()
        {
            RuleFor(p => p.FormId).NotNull().WithErrorCode("FormId").WithMessage("FormId cannot be null");
            RuleFor(p => p.Name).Matches(onlyAlphabet).WithErrorCode("Name").WithMessage("Name should contains only Alphabets");
           // RuleFor(p => p.ContactNumber).Matches(onlyNumbers).WithErrorCode("ContactNumber").WithMessage("ContactNumber should contains only numbers");
            RuleFor(p => p.Relationship).Matches(onlyAlphabet).WithErrorCode("Relationship").WithMessage("Relationship should contains only Alphabets");
            RuleFor(p => p.NameofparentIncaseofstaffWard).Matches(onlyAlphabet).WithErrorCode("NameofparentIncaseofstaffWard").WithMessage("NameofparentIncaseofstaffWard should contains only Alphabets");

            RuleFor(p => p.ContactNumber)
             .Cascade(CascadeMode.Stop)
             .Must(PhoneNumberValidation)
             .When(p => !string.IsNullOrWhiteSpace(p.ContactNumber))
             .WithMessage("Emergency Contact Details: Invalid Emergency Phone Number Format.");
        }

        private bool PhoneNumberValidation(string? Contact)
        {
            // Custom logic to validate phone number
            return Contact != null && !Contact.All(c => c == '0');
        }
    }
}
