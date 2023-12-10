using AutoMapper;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers.MasterDataManagers
{
    public class MstPermissionService : IGenericService<MstPermissionDto>
    {
        private IMapper _mapper;
        public MstPermissionService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstPermissions.FirstOrDefault(e => e.PermissionId == id);
                if (entity != null)
                {
                    dbContext.MstPermissions.Remove(entity);
                    dbContext.SaveChanges();
                }

                return true;
            }

        }

        public List<MstPermissionDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstPermissions.ToList();
                return _mapper.Map<List<MstPermissionDto>>(result);
            }
        }

        public MstPermissionDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstPermissions?.FirstOrDefault(e => e.PermissionId.Equals(id));
                return _mapper.Map<MstPermissionDto>(result);
            }
        }

        public bool InsertOrUpdate(MstPermissionDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                    if (entity.PermissionId != 0)
                    {
                        var dbentity = dbContext.MstPermissions.FirstOrDefault(e => e.PermissionId == entity.PermissionId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstPermission>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstPermissions.Add(_mapper.Map<MstPermission>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }
    }
}
