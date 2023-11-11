using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Api.Models.ModelsDto;

namespace VVPSMS.Service.Validators.AdmissionFormValidators
{
    public class AdmissionDocumentsValidator : AbstractValidator<AdmissionDocumentDto>
    {
        public AdmissionDocumentsValidator()
        {
            RuleFor(p => p.FormId).NotNull().WithErrorCode("FormId").WithMessage("FormId cannot be null");
            RuleFor(p => p.MstdocumenttypesId).NotNull().WithErrorCode("MstdocumenttypesId").WithMessage("MstdocumenttypesId cannot be null")
                .GreaterThan(0).WithErrorCode("MstdocumenttypesId").WithMessage("MstdocumenttypesId should be greater 0");

            RuleFor(p => p.DocumentName).NotNull().WithErrorCode("DocumentName").WithMessage("DocumentName cannot be null");
            RuleFor(p => p.DocumentName).NotEmpty().WithErrorCode("DocumentName").WithMessage("DocumentName cannot be empty");
            
        }
    }
}
