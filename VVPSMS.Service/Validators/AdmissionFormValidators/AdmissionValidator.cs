using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Validators.AdmissionFormValidators
{
    public class AdmissionValidator : AbstractValidator<AdmissionFormDto>
    {
        public AdmissionValidator()
        {
            RuleFor(p => p.AcademicId).NotNull()
                .WithErrorCode("AcademicId")
                .WithMessage("AcademicId cannot be null")
                .GreaterThan(0).WithErrorCode("AcademicId").WithMessage("AcademicId must be greater than 0");
        
            RuleFor(p => p.SchoolId).NotNull()
               .WithErrorCode("SchoolId")
               .WithMessage("SchoolId cannot be null")
               .GreaterThan(0).WithErrorCode("SchoolId").WithMessage("SchoolId must be greater than 0");


            RuleFor(p => p.StreamId).NotNull()
               .WithErrorCode("StreamId")
               .WithMessage("StreamId cannot be null")
               .GreaterThan(0).WithErrorCode("StreamId").WithMessage("StreamId must be greater than 0");

            RuleFor(p => p.GradeId).NotNull()
               .WithErrorCode("GradeId")
               .WithMessage("GradeId cannot be null")
               .GreaterThan(0).WithErrorCode("GradeId").WithMessage("GradeId must be greater than 0");


            RuleFor(p => p.ClassId).NotNull()
               .WithErrorCode("ClassId")
               .WithMessage("ClassId cannot be null")
               .GreaterThan(0).WithErrorCode("ClassId").WithMessage("ClassId must be greater than 0");


            //Documents
            RuleForEach(x => x.AdmissionDocuments).SetValidator(new AdmissionDocumentsValidator());
            //Student Info Details
            RuleForEach(x => x.StudentInfoDetails).SetValidator(new AdmissionStudentInfoDetailsValidator());

            RuleForEach(x => x.AdmissionEnquiryDetails).SetValidator(new AdmissionEnquiryDetailsValidator());
            RuleForEach(x => x.EmergencyContactDetails).SetValidator(new EmergencyContactDetailsValidator());
            RuleForEach(x => x.FamilyOrGuardianInfoDetails).SetValidator(new FamilyOrGuardianInfoDetailsValidator());
            RuleForEach(x => x.PreviousSchoolDetails).SetValidator(new PreviousSchoolDetailsValidator());
            RuleForEach(x => x.SiblingInfos).SetValidator(new SiblingInfoDetailsValidator());
            RuleForEach(x => x.StudentHealthInfoDetails).SetValidator(new StudentHealthInfoDetailsValidator());
            RuleForEach(x => x.StudentIllnessDetails).SetValidator(new StudentIllnessDetailsValidator());
            RuleForEach(x => x.TransportDetails).SetValidator(new TransportDetailsValidator());

        }
    }
}
