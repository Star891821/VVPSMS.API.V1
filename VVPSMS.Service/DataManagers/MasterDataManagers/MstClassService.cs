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
        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstClasses.FirstOrDefault(e => e.ClassId == id);
                if (entity != null)
                {
                    dbContext.MstClasses.Remove(entity);
                    dbContext.SaveChanges();
                }
                return true;
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

        public bool InsertOrUpdate(MstClassDto entity)
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
                            dbContext.MstClasses.Update(_mapper.Map<MstClass>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstClasses.Add(_mapper.Map<MstClass>(entity));
                    }
                    dbContext.SaveChanges();
                }

                return true;
            }
        }

    }
}
