using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstSchoolService : IGenericService<MstSchoolDto>
    {
        private IMapper _mapper;
        public MstSchoolService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstSchools.FirstOrDefault(e => e.SchoolId == id);
                if (entity != null)
                {
                    dbContext.MstSchools.Remove(entity);
                    dbContext.SaveChanges();
                }

                return true;
            }

        }

        public List<MstSchoolDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstSchools.ToList();
                return _mapper.Map<List<MstSchoolDto>>(result);
            }
        }

        public MstSchoolDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstSchools?.FirstOrDefault(e => e.SchoolId.Equals(id));
                return _mapper.Map<MstSchoolDto>(result);
            }
        }

        public bool InsertOrUpdate(MstSchoolDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.SchoolId != 0)
                    {
                        var dbentity = dbContext.MstSchools.FirstOrDefault(e => e.SchoolId == entity.SchoolId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstSchool>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstSchools.Add(_mapper.Map<MstSchool>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

    }
}
