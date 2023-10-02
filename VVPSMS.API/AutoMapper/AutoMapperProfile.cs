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
            CreateMap<StudentInfoDetail, StudentInfoDetailDto>().ReverseMap();
            CreateMap<FamilyOrGuardianInfoDetail, FamilyOrGuardianInfoDetailDto>().ReverseMap();
            CreateMap<SiblingInfo, SiblingInfoDto>().ReverseMap();
            CreateMap<EmergencyContactDetail, EmergencyContactDetailDto>().ReverseMap();
            CreateMap<PreviousSchoolDetail, PreviousSchoolDetailDto>().ReverseMap();
            CreateMap<StudentHealthInfoDetail, StudentHealthInfoDetailDto>().ReverseMap();
            CreateMap<StudentIllnessDetail, StudentIllnessDetailDto>().ReverseMap();
            CreateMap<AdmissionEnquiryDetail, AdmissionEnquiryDetailDto>().ReverseMap();
            CreateMap<AdmissionDocument, AdmissionDocumentDto>().ReverseMap();
            CreateMap<TransportDetail, TransportDetailDto>().ReverseMap();
            CreateMap<MstSchool, MstSchoolDto>().ReverseMap();
            CreateMap<MstSchoolGrade, MstSchoolGradeDto>().ReverseMap();
            CreateMap<MstClass, MstClassDto>().ReverseMap();
            CreateMap<MstAcademicYear, MstAcademicYearDto>().ReverseMap();
            CreateMap<MstSchoolStream, MstSchoolStreamDto>().ReverseMap();
            CreateMap<MstUserRole, MstUserRoleDto>().ReverseMap();
            CreateMap<MstUser, MstUserDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<StudentDocument, StudentDocumentDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<TeacherDocument, TeacherDocumentDto>().ReverseMap();
            CreateMap<Parent, ParentDto>().ReverseMap();
            CreateMap<ParentDocument, ParentDocumentDto>().ReverseMap();
            CreateMap<MstDocumentType,MstDocumentTypesDto>().ReverseMap();
        }
    }
}
