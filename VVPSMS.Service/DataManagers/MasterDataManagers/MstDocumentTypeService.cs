using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstDocumentTypeService : IGenericService<MstDocumentTypesDto>
    {
        private IMapper _mapper;
        public MstDocumentTypeService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstDocumentTypes.FirstOrDefault(e=>e.MstdocumenttypesId==id);
                if (entity != null)
                {
                    dbContext.MstDocumentTypes.Remove(entity);
                    dbContext.SaveChanges();
                }
                return true;
            }

        }

        public List<MstDocumentTypesDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstDocumentTypes.ToList();
                return _mapper.Map<List<MstDocumentTypesDto>>(result);
            }
        }

        public MstDocumentTypesDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstDocumentTypes?.FirstOrDefault(e => e.MstdocumenttypesId.Equals(id));
                return _mapper.Map<MstDocumentTypesDto>(result);
            }
        }

        public bool InsertOrUpdate(MstDocumentTypesDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.MstdocumenttypesId != 0)
                    {
                        var dbentity = dbContext.MstDocumentTypes.FirstOrDefault(e => e.MstdocumenttypesId == entity.MstdocumenttypesId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstDocumentType>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstDocumentTypes.Add(_mapper.Map<MstDocumentType>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }
    }
}
