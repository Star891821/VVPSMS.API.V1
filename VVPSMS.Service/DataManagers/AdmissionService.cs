using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;
using Azure;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace VVPSMS.Service.DataManagers
{
    public class AdmissionService : IGenericService<AdmissionFormDto>,IAdmissionDocumentService
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

        public List<AdmissionDocumentDto> GetAllDocumentsById(int formid)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.AdmissionDocuments.Where(e => e.FormId == formid).ToList();
                return _mapper.Map<List<AdmissionDocumentDto>>(result);
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
                            dbContext.AdmissionForms.Update(_mapper.Map<AdmissionForm>(entity));
                        }
                    }
                    else
                    {
                        dbContext.AdmissionForms.Add(_mapper.Map<AdmissionForm>(entity));
                        
                    }
                    UpdateDocuments(dbContext,entity);
                    dbContext.SaveChanges();
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
        private  void UpdateDocuments(VvpsmsdbContext dbContext, AdmissionFormDto mstAdmissionFormDto)
        {
            if (mstAdmissionFormDto.listOfAdmissionDocuments != null)
            {
                    var existing = dbContext.AdmissionDocuments.Where(e => e.FormId == mstAdmissionFormDto.FormId).ToList();
                    if (existing.Any())
                    {
                        dbContext.AdmissionDocuments.RemoveRange(existing);
                        dbContext.SaveChanges();
                    }
                    foreach (var item in mstAdmissionFormDto.listOfAdmissionDocuments)
                    {
                        var mstArAdmissionDocument = new AdmissionDocument
                        {
                            FormId = mstAdmissionFormDto.FormId,
                            DocumentName = item.DocumentName,
                            DocumentPath = item.DocumentPath,
                            CreatedAt = mstAdmissionFormDto.CreatedAt,
                            CreatedBy = mstAdmissionFormDto.CreatedBy,
                            ModifiedAt = mstAdmissionFormDto.ModifiedAt,
                            ModifiedBy = mstAdmissionFormDto.ModifiedBy
                        };

                        dbContext.AdmissionDocuments.Add(mstArAdmissionDocument);
                        dbContext.SaveChanges();
                    }


            }
        }

       
    }
}
