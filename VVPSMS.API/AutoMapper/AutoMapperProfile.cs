using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdmissionForm, AdmissionFormDto>();
            CreateMap<MstSchool, MstSchoolDto>();
            CreateMap<MstSchoolGrade, MstSchoolGradeDto>();
            CreateMap<MstClass, MstClassDto>();
            CreateMap<MstAcademicYear, MstAcademicYearDto>();
            CreateMap<MstSchoolStream, MstSchoolStreamDto>();
            CreateMap<MstUserRole, MstUserRoleDto>();
            CreateMap<AdmissionDocument, AdmissionDocumentDto>();
        }
    }
}
