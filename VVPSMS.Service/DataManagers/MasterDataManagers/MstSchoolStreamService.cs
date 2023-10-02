using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstSchoolStreamService : IGenericService<MstSchoolStreamDto>
    {
        private IMapper _mapper;
        public MstSchoolStreamService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstSchoolStreams.FirstOrDefault(e => e.StreamId == id);
                if (entity != null)
                {
                    dbContext.MstSchoolStreams.Remove(entity);
                    dbContext.SaveChanges();
                }
                return true;
            }

        }

        public List<MstSchoolStreamDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstSchoolStreams.ToList();
                return _mapper.Map<List<MstSchoolStreamDto>>(result);
            }
        }

        public MstSchoolStreamDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstSchoolStreams?.FirstOrDefault(e => e.StreamId.Equals(id));
                return _mapper.Map<MstSchoolStreamDto>(result);
            }
        }

        public bool InsertOrUpdate(MstSchoolStreamDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.StreamId != 0)
                    {
                        var dbentity = dbContext.MstSchoolStreams.FirstOrDefault(e => e.StreamId == entity.StreamId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstSchoolStream>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstSchoolStreams.Add(_mapper.Map<MstSchoolStream>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

    }
}
