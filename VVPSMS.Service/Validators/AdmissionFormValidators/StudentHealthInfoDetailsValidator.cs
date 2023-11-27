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
    public class StudentHealthInfoDetailsValidator : AbstractValidator<StudentHealthInfoDetailDto>
    {
        readonly Regex onlyAlphabet = new Regex("^\\D+$");

        readonly Regex AlphaNumeric = new Regex("^[0-9a-zA-Z\" \"''-_@#/]+$");
        public StudentHealthInfoDetailsValidator()
        {
            RuleFor(p => p.FormId).NotNull().WithErrorCode("FormId").WithMessage("FormId cannot be null");

            RuleFor(p => p.ChildName).NotEmpty().WithErrorCode("ChildName").WithMessage("ChildName cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("ChildName").WithMessage("ChildName should contains only Alphabets");
            RuleFor(p => p.ImmunizationStatus).NotEmpty().WithErrorCode("ImmunizationStatus").WithMessage("ImmunizationStatus cannot be Empty")
                .Matches(onlyAlphabet).WithErrorCode("ImmunizationStatus").WithMessage("ImmunizationStatus should contains only Alphabets");
            RuleFor(p => p.RegularmedicineTakenbystudent).Matches(onlyAlphabet).WithErrorCode("RegularmedicineTakenbystudent").WithMessage("RegularmedicineTakenbystudent should contains only Alphabets");
            RuleFor(p => p.AllergiesIfAny).Matches(onlyAlphabet).WithErrorCode("AllergiesIfAny").WithMessage("AllergiesIfAny should contains only Alphabets");
            RuleFor(p => p.SpecialNeeds).Matches(onlyAlphabet).WithErrorCode("SpecialNeeds").WithMessage("SpecialNeeds should contains only Alphabets");
            RuleFor(p => p.LearningDisabilities).Matches(onlyAlphabet).WithErrorCode("LearningDisabilities").WithMessage("LearningDisabilities should contains only Alphabets");
            
            RuleFor(p => p.Class).NotEmpty().WithErrorCode("Class").WithMessage("Class cannot be Empty")
                .Matches(AlphaNumeric).WithErrorCode("Class").WithMessage("Class should contains Alpha Numeric Characters");
            RuleFor(p => p.BloodGroup).NotEmpty().WithErrorCode("BloodGroup").WithMessage("BloodGroup cannot be Empty");
               // .Matches(AlphaNumeric).WithErrorCode("BloodGroup").WithMessage("BloodGroup should contains Alpha Numeric Characters");
            RuleFor(p => p.Height).NotEmpty().WithErrorCode("Height").WithMessage("Height cannot be Empty")
                .Matches(AlphaNumeric).WithErrorCode("Height").WithMessage("Height should contains Alpha Numeric Characters");
            RuleFor(p => p.Weight).NotEmpty().WithErrorCode("Weight").WithMessage("Weight cannot be Empty")
                .Matches(AlphaNumeric).WithErrorCode("Weight").WithMessage("Weight should contains Alpha Numeric Characters");
            RuleFor(p => p.VisionLeft).Matches(AlphaNumeric).WithErrorCode("VisionLeft").WithMessage("VisionLeft should contains Alpha Numeric Characters");
            RuleFor(p => p.VisionRight).Matches(AlphaNumeric).WithErrorCode("VisionRight").WithMessage("VisionRight should contains Alpha Numeric Characters");
            RuleFor(p => p.HealthHistory).Matches(AlphaNumeric).WithErrorCode("HealthHistory").WithMessage("HealthHistory should contains Alpha Numeric Characters");
            RuleFor(p => p.IdentificationMarks).Matches(AlphaNumeric).WithErrorCode("IdentificationMarks").WithMessage("IdentificationMarks should contains Alpha Numeric Characters");

        }
    }
}
