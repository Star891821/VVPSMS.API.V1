using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstClassService : IGenericService<MstClassDto>
    {
        private IMapper _mapper;
        public MstClassService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<MstClassDto> Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstClasses.FirstOrDefault(e => e.ClassId == id);
                if (entity != null)
                {
                    dbContext.MstClasses.Remove(entity);
                    dbContext.SaveChanges();
                }
                var result = dbContext.MstClasses.ToList();
                return _mapper.Map<List<MstClassDto>>(result);
            }
        }

        public List<MstClassDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstClasses.ToList();
                return _mapper.Map<List<MstClassDto>>(result);
            }
        }

        public MstClassDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstClasses?.FirstOrDefault(e => e.ClassId.Equals(id));
                return _mapper.Map<MstClassDto>(result);
            }
        }

        public List<MstClassDto> InsertOrUpdate(MstClassDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.ClassId != 0)
                    {
                        var dbentity = dbContext.MstClasses.FirstOrDefault(e => e.ClassId == entity.ClassId);

                        if (dbentity != null)
                        {
                            dbContext.MstClasses.Update(ConvertFromDto(dbentity, entity));
                        }
                    }
                    else
                    {
                        dbContext.MstClasses.Add(ConvertFromDto(new MstClass(), entity));
                    }
                    dbContext.SaveChanges();
                }

                var result = dbContext.MstClasses.ToList();
                return _mapper.Map<List<MstClassDto>>(result);
            }
        }


        private static MstClass ConvertFromDto(MstClass mstClass, MstClassDto mstClassDto)
        {
            mstClass.ClassName = mstClassDto.ClassName;
            mstClass.ActiveYn = mstClassDto.ActiveYn;
            mstClass.CreatedBy = mstClassDto.CreatedBy;
            mstClass.CreatedAt = mstClassDto.CreatedAt;
            mstClass.ModifiedBy = mstClassDto.ModifiedBy;
            mstClass.ModifiedAt = mstClassDto.ModifiedAt;
            return mstClass;
        }
    }
}
