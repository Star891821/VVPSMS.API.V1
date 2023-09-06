using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;

namespace VVPSMS.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdmissionForm, AdmissionFormDto>().ReverseMap();
            CreateMap<MstSchool, MstSchoolDto>().ReverseMap();
            CreateMap<MstSchoolGrade, MstSchoolGradeDto>().ReverseMap();
            CreateMap<MstClass, MstClassDto>().ReverseMap();
            CreateMap<MstAcademicYear, MstAcademicYearDto>().ReverseMap();
            CreateMap<MstSchoolStream, MstSchoolStreamDto>().ReverseMap();
            CreateMap<MstUserRole, MstUserRoleDto>().ReverseMap();
            CreateMap<AdmissionDocument, AdmissionDocumentDto>().ReverseMap();
        }
    }
}
