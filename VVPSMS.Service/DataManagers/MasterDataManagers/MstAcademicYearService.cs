using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstAcademicYearService : IGenericService<MstAcademicYearDto>
    {
        private IMapper _mapper;
        public MstAcademicYearService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<MstAcademicYearDto> Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstAcademicYears.FirstOrDefault(e => e.AcademicId == id);
                if (entity != null)
                {
                    dbContext.MstAcademicYears.Remove(entity);
                    dbContext.SaveChanges();
                }
                var result = dbContext.MstAcademicYears.ToList();
                return _mapper.Map<List<MstAcademicYearDto>>(result);
            }
        }

        public List<MstAcademicYearDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstAcademicYears.ToList();
                return _mapper.Map<List<MstAcademicYearDto>>(result);
            }
        }

        public MstAcademicYearDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstAcademicYears?.FirstOrDefault(e => e.AcademicId.Equals(id));
                return _mapper.Map<MstAcademicYearDto>(result);
            }
        }

        public List<MstAcademicYearDto> InsertOrUpdate(MstAcademicYearDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.AcademicId != 0)
                    {
                        var dbentity = dbContext.MstAcademicYears.FirstOrDefault(e => e.AcademicId == entity.AcademicId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstAcademicYear>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstAcademicYears.Add(_mapper.Map<MstAcademicYear>(entity));
                    }
                    dbContext.SaveChanges();
                }

                var result = dbContext.MstAcademicYears.ToList();
                return _mapper.Map<List<MstAcademicYearDto>>(result);
            }
        }

    }
}
