using Microsoft.EntityFrameworkCore;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Parents;

namespace VVPSMS.Service.DataManagers.ParentDataManagers
{
    public class ParentService : GenericService<Parent>, IParentService
    {
        public ParentService(VvpsmsdbContext context) : base(context)
        {
        }
        public override async Task<bool> InsertOrUpdate(Parent entity)
        {
            try
            {
                var exist = await dbSet.Where(x => x.ParentId == entity.ParentId)
                                       .FirstOrDefaultAsync();

                if (exist != null)
                {
                    await base.InsertOrUpdate(UpdatedParentEntity(exist, entity));
                }
                else
                {
                    await base.InsertOrUpdate(entity);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private Parent UpdatedParentEntity(Parent entityToUpdate, Parent entity)
        {
            entityToUpdate.ParentUsername = entity.ParentUsername;
            entityToUpdate.ParentPassword = entity.ParentPassword;
            entityToUpdate.ParentGivenName = entity.ParentGivenName;
            entityToUpdate.ParentSurname = entity.ParentSurname;
            entityToUpdate.ParentPhone = entity.ParentPhone;
            entityToUpdate.ParentRole = entity.ParentRole;
            entityToUpdate.ParentLoginType = entity.ParentLoginType;
            entityToUpdate.Enforce2Fa = entity.Enforce2Fa;
            entityToUpdate.CreatedAt = entity.CreatedAt;
            entityToUpdate.CreatedBy = entity.CreatedBy;
            entityToUpdate.ModifiedAt = entity.ModifiedAt;
            entityToUpdate.ModifiedBy = entity.ModifiedBy;
            entityToUpdate.LastloginAt = entity.LastloginAt;
            return entityToUpdate;
        }
    }
}
