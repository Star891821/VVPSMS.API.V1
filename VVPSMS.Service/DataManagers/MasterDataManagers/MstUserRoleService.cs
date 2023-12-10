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


        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstUserRoles.FirstOrDefault(e => e.RoleId == id);

                if (entity != null)
                {
                    var roleTypeEntity = dbContext.MstRoleTypes.FirstOrDefault(e => e.RoletypeId == entity.RoletypeId);
                    if (roleTypeEntity != null)
                    {
                        if (roleTypeEntity.RoletypeName != "Seeded")
                        {
                            dbContext.MstUserRoles.Remove(entity);
                            dbContext.SaveChanges();
                            
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
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

        public bool InsertOrUpdate(MstUserRoleDto entity)
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
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstUserRole>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstUserRoles.Add(_mapper.Map<MstUserRole>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }
    }
}
