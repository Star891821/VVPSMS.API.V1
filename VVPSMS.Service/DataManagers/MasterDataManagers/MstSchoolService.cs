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

        public List<MstSchoolDto> Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstSchools.FirstOrDefault(e => e.SchoolId == id);
                if (entity != null)
                {
                    dbContext.MstSchools.Remove(entity);
                    dbContext.SaveChanges();
                }

                var result = dbContext.MstSchools.ToList();
                return _mapper.Map<List<MstSchoolDto>>(result);
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

        public List<MstSchoolDto> InsertOrUpdate(MstSchoolDto entity)
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
                            dbContext.MstSchools.Update(ConvertFromDto(dbentity, entity));
                        }
                    }
                    else
                    {
                        dbContext.MstSchools.Add(ConvertFromDto(new MstSchool(), entity));
                    }
                    dbContext.SaveChanges();
                }
                var result = dbContext.MstSchools.ToList();
                return _mapper.Map<List<MstSchoolDto>>(result);
            }
        }


        private static MstSchool ConvertFromDto(MstSchool mstSchool, MstSchoolDto mstSchoolDto)
        {
            mstSchool.SchoolName = mstSchoolDto.SchoolName;
            mstSchool.SchoolCode = mstSchoolDto.SchoolCode;
            mstSchool.SchoolDescription = mstSchoolDto.SchoolDescription;
            mstSchool.SchoolAddress1 = mstSchoolDto.SchoolAddress1;
            mstSchool.SchoolAddress2 = mstSchoolDto.SchoolAddress2;
            mstSchool.SchoolLogopath = mstSchoolDto.SchoolLogopath;
            mstSchool.SchoolPhone = mstSchoolDto.SchoolPhone;
            mstSchool.SchoolWebsite = mstSchoolDto.SchoolWebsite;
            mstSchool.SchoolCoordinates = mstSchoolDto.SchoolCoordinates;
            mstSchool.SchoolLandmark = mstSchoolDto.SchoolLandmark;
            mstSchool.SchoolDistrict = mstSchoolDto.SchoolDistrict;
            mstSchool.SchoolState = mstSchoolDto.SchoolState;
            mstSchool.SchoolCountry = mstSchoolDto.SchoolCountry;
            mstSchool.StreamsAvailable = mstSchoolDto.StreamsAvailable;
            mstSchool.GradesAvailable = mstSchoolDto.GradesAvailable;
            mstSchool.ClassesAvailable = mstSchoolDto.ClassesAvailable;
            mstSchool.ActiveYn = mstSchoolDto.ActiveYn;
            mstSchool.CreatedBy = mstSchoolDto.CreatedBy;
            mstSchool.CreatedAt = mstSchoolDto.CreatedAt;
            mstSchool.ModifiedAt = mstSchoolDto.ModifiedAt;
            mstSchool.ModifiedBy = mstSchoolDto.ModifiedBy;
            return mstSchool;
        }

    }
}
