using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstSchoolGradeService : IGenericService<MstSchoolGradeDto>
    {
        private IMapper _mapper;
        public MstSchoolGradeService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstSchoolGrades.FirstOrDefault(e => e.GradeId == id);
                if (entity != null)
                {
                    dbContext.MstSchoolGrades.Remove(entity);
                    dbContext.SaveChanges();
                }
                return true;
            }

        }

        public List<MstSchoolGradeDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstSchoolGrades.ToList();
                return _mapper.Map<List<MstSchoolGradeDto>>(result);
            }
        }

        public MstSchoolGradeDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstSchoolGrades?.FirstOrDefault(e => e.GradeId.Equals(id));
                return _mapper.Map<MstSchoolGradeDto>(result);
            }
        }

        public bool InsertOrUpdate(MstSchoolGradeDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.GradeId != 0)
                    {
                        var dbentity = dbContext.MstSchoolGrades.FirstOrDefault(e => e.GradeId == entity.GradeId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstSchoolGrade>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstSchoolGrades.Add(_mapper.Map<MstSchoolGrade>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

    }
}
