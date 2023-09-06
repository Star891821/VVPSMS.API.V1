using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstUserRoleService : IGenericService<MstUserRoleDto>
    {
        private IMapper _mapper;
        public MstUserRoleService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public List<MstUserRoleDto> Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstUserRoles.FirstOrDefault(e => e.RoleId == id);
                if (entity != null)
                {
                    dbContext.MstUserRoles.Remove(entity);
                    dbContext.SaveChanges();
                }

                var result = dbContext.MstUserRoles.ToList();
                return _mapper.Map<List<MstUserRoleDto>>(result);
            }

        }

        public List<MstUserRoleDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstUserRoles.ToList();
                return _mapper.Map<List<MstUserRoleDto>>(result);
            }
        }

        public MstUserRoleDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstUserRoles?.FirstOrDefault(e => e.RoleId.Equals(id));
                return _mapper.Map<MstUserRoleDto>(result);
            }
        }

        public List<MstUserRoleDto> InsertOrUpdate(MstUserRoleDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.RoleId != 0)
                    {
                        var dbentity = dbContext.MstUserRoles.FirstOrDefault(e => e.RoleId == entity.RoleId);

                        if (dbentity != null)
                        {
                            dbContext.MstUserRoles.Update(ConvertFromDto(dbentity, entity));
                        }
                    }
                    else
                    {
                        dbContext.MstUserRoles.Add(ConvertFromDto(new MstUserRole(), entity));
                    }
                    dbContext.SaveChanges();
                }
                var result = dbContext.MstUserRoles.ToList();
                return _mapper.Map<List<MstUserRoleDto>>(result);
            }
        }


        private static MstUserRole ConvertFromDto(MstUserRole mstUserRole, MstUserRoleDto mstUserRoleDto)
        {
            mstUserRole.RoleName = mstUserRoleDto.RoleName;
            mstUserRole.ActiveYn = mstUserRoleDto.ActiveYn;
            mstUserRole.CreatedBy = mstUserRoleDto.CreatedBy;
            mstUserRole.CreatedAt = mstUserRoleDto.CreatedAt;
            mstUserRole.ModifiedBy = mstUserRoleDto.ModifiedBy;
            mstUserRole.ModifiedAt = mstUserRoleDto.ModifiedAt;
            return mstUserRole;
        }
    }
}
