using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Validators.AdmissionFormValidators
{
    public class AdmissionEnquiryDetailsValidator : AbstractValidator<AdmissionEnquiryDetailDto>
    {
        public AdmissionEnquiryDetailsValidator()
        {
            RuleFor(p => p.FormId).NotNull()
                .WithErrorCode("FormId")
                .WithMessage("FormId cannot be null");
            RuleFor(p => p.MstenquiryquestiondetailsId).NotNull().WithErrorCode("MstenquiryquestiondetailsId").WithMessage("MstenquiryquestiondetailsId cannot be null")
                .GreaterThan(0).WithErrorCode("MstenquiryquestiondetailsId").WithMessage("MstenquiryquestiondetailsId should be greater 0");

            RuleFor(p => p.EnquiryResponse).NotEmpty()
             .WithErrorCode("EnquiryResponse")
             .WithMessage("EnquiryResponse cannot be empty");
        }
    }
}
