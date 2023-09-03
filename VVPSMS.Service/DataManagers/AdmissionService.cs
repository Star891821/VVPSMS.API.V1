using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;
using Azure;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace VVPSMS.Service.DataManagers
{
    public class AdmissionService : IGenericService<AdmissionFormDto>
    {
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        public AdmissionService(IMapper mapper, IConfiguration configuration, IStorageService storageService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _storageService = storageService;
        }

        public List<AdmissionFormDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.AdmissionForms.ToList();
                return _mapper.Map<List<AdmissionFormDto>>(result);
            }
        }

        public AdmissionFormDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.AdmissionForms?.FirstOrDefault(e => e.FormId.Equals(id));
                return _mapper.Map<AdmissionFormDto>(result);
            }
        }

        public List<AdmissionFormDto> InsertOrUpdate(AdmissionFormDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.SchoolId != 0)
                    {
                        var dbentity = dbContext.AdmissionForms.FirstOrDefault(e => e.FormId == entity.FormId);

                        if (dbentity != null)
                        {
                            dbContext.AdmissionForms.Update(ConvertFromDto(dbentity, entity));
                            dbContext.SaveChanges();
                        }
                    }
                    else
                    {
                        dbContext.AdmissionForms.Add(ConvertFromDto(new AdmissionForm(), entity));
                        dbContext.SaveChanges();
                    }
                    UpdateDocuments(entity);
                }
                var result = dbContext.AdmissionForms.ToList();
                return _mapper.Map<List<AdmissionFormDto>>(result);
            }
        }

        public List<AdmissionFormDto> Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.AdmissionForms.FirstOrDefault(e => e.FormId == id);
                if (entity != null)
                {
                    dbContext.AdmissionForms.Remove(entity);
                    dbContext.SaveChanges();

                }
                var result = dbContext.AdmissionForms.ToList();
                return _mapper.Map<List<AdmissionFormDto>>(result);
            }
        }
        private static AdmissionForm ConvertFromDto(AdmissionForm mstAdmissionForm, AdmissionFormDto mstAdmissionFormDto)
        {
            mstAdmissionForm.AcademicId = mstAdmissionFormDto.AcademicId;
            mstAdmissionForm.SchoolId = mstAdmissionFormDto.SchoolId;
            mstAdmissionForm.StreamId = mstAdmissionFormDto.StreamId;
            mstAdmissionForm.GradeId = mstAdmissionFormDto.GradeId;
            mstAdmissionForm.ClassId = mstAdmissionFormDto.ClassId;
            mstAdmissionForm.StudentGivenName = mstAdmissionFormDto.StudentGivenName;
            mstAdmissionForm.StudentSurname = mstAdmissionFormDto.StudentSurname;
            mstAdmissionForm.StudentDob = mstAdmissionFormDto.StudentDob;
            mstAdmissionForm.StudentGender = mstAdmissionFormDto.StudentGender;
            mstAdmissionForm.StudentAge = mstAdmissionFormDto.StudentAge;
            mstAdmissionForm.ParentName1 = mstAdmissionFormDto.ParentName1;
            mstAdmissionForm.HighestQualification1 = mstAdmissionFormDto.HighestQualification1;
            mstAdmissionForm.ParentContact1 = mstAdmissionFormDto.ParentContact1;
            mstAdmissionForm.ParentEmail1 = mstAdmissionFormDto.ParentEmail1;
            mstAdmissionForm.ParentName2 = mstAdmissionFormDto.ParentName2;
            mstAdmissionForm.HighestQualification2 = mstAdmissionFormDto.HighestQualification2;
            mstAdmissionForm.ParentContact2 = mstAdmissionFormDto.ParentContact2;
            mstAdmissionForm.ParentEmail2 = mstAdmissionFormDto.ParentEmail2;
            mstAdmissionForm.PreferredContact = mstAdmissionFormDto.PreferredContact;
            mstAdmissionForm.Declaration = mstAdmissionFormDto.Declaration;
            mstAdmissionForm.SiblingsYn = mstAdmissionFormDto.SiblingsYn;
            mstAdmissionForm.SpecialNeeds = mstAdmissionFormDto.SpecialNeeds;
            mstAdmissionForm.LearningDisabilities = mstAdmissionFormDto.LearningDisabilities;
            mstAdmissionForm.PreviousSchool = mstAdmissionFormDto.PreviousSchool;
            mstAdmissionForm.ReasonDescription = mstAdmissionFormDto.ReasonDescription;
            mstAdmissionForm.StudentExpelled = mstAdmissionFormDto.StudentExpelled;
            mstAdmissionForm.DetailsExpulsion = mstAdmissionFormDto.DetailsExpulsion;
            mstAdmissionForm.AdmissionStatus = mstAdmissionFormDto.AdmissionStatus;
            mstAdmissionForm.CreatedAt = mstAdmissionFormDto.CreatedAt;
            mstAdmissionForm.CreatedBy = mstAdmissionFormDto.CreatedBy;
            mstAdmissionForm.ModifiedAt = mstAdmissionFormDto.ModifiedAt;
            mstAdmissionForm.ModifiedBy = mstAdmissionFormDto.ModifiedBy;
            return mstAdmissionForm;
        }

        private static void UpdateDocuments(AdmissionFormDto mstAdmissionFormDto)
        {
            if (mstAdmissionFormDto.Documents != null)
            {
                using (var dbContext = new VvpsmsdbContext())
                {
                    var existing = dbContext.ArAdmissionDocuments.Where(e => e.FormId == mstAdmissionFormDto.FormId).ToList();
                    if (existing.Any())
                    {
                        dbContext.ArAdmissionDocuments.RemoveRange(existing);
                        dbContext.SaveChanges();
                    }
                    foreach (var item in mstAdmissionFormDto.Documents)
                    {
                        var mstArAdmissionDocument = new ArAdmissionDocument
                        {
                            FormId = mstAdmissionFormDto.FormId,
                            DocumentName = item.DocumentName,
                            DocumentPath = item.DocumentPath,
                            CreatedAt = mstAdmissionFormDto.CreatedAt,
                            CreatedBy = mstAdmissionFormDto.CreatedBy,
                            ModifiedAt = mstAdmissionFormDto.ModifiedAt,
                            ModifiedBy = mstAdmissionFormDto.ModifiedBy
                        };

                        dbContext.ArAdmissionDocuments.Add(mstArAdmissionDocument);
                        dbContext.SaveChanges();
                    }
                }
            }
        }

    }
}
