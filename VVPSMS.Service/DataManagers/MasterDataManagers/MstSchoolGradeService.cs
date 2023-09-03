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
        public List<MstSchoolGradeDto> Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstSchoolGrades.FirstOrDefault(e => e.GradeId == id);
                if (entity != null)
                {
                    dbContext.MstSchoolGrades.Remove(entity);
                    dbContext.SaveChanges();
                }
                var result = dbContext.MstSchoolGrades.ToList();
                return _mapper.Map<List<MstSchoolGradeDto>>(result);
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

        public List<MstSchoolGradeDto> InsertOrUpdate(MstSchoolGradeDto entity)
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
                            dbContext.MstSchoolGrades.Update(ConvertFromDto(dbentity, entity));
                        }
                    }
                    else
                    {
                        dbContext.MstSchoolGrades.Add(ConvertFromDto(new MstSchoolGrade(), entity));
                    }
                    dbContext.SaveChanges();
                }
                var result = dbContext.MstSchoolGrades.ToList();
                return _mapper.Map<List<MstSchoolGradeDto>>(result);
            }
        }

        private static MstSchoolGrade ConvertFromDto(MstSchoolGrade mstSchoolGrade, MstSchoolGradeDto mstSchoolGradeDto)
        {
            mstSchoolGrade.GradeName = mstSchoolGradeDto.GradeName;
            mstSchoolGrade.ActiveYn = mstSchoolGradeDto.ActiveYn;
            mstSchoolGrade.CreatedBy = mstSchoolGradeDto.CreatedBy;
            mstSchoolGrade.CreatedAt = mstSchoolGradeDto.CreatedAt;
            mstSchoolGrade.ModifiedBy = mstSchoolGradeDto.ModifiedBy;
            mstSchoolGrade.ModifiedAt = mstSchoolGradeDto.ModifiedAt;
            return mstSchoolGrade;
        }
    }
}
