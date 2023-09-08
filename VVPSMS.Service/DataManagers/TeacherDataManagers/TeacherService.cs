using Microsoft.EntityFrameworkCore;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Teachers;

namespace VVPSMS.Service.DataManagers.TeacherDataManagers
{
    public class TeacherService : GenericService<Teacher>, ITeacherService
    {
        public TeacherService(VvpsmsdbContext context) : base(context)
        {
        }
        public override async Task<bool> InsertOrUpdate(Teacher entity)
        {
            try
            {
                var exist = await dbSet.Where(x => x.TeacherId == entity.TeacherId)
                                       .FirstOrDefaultAsync();

                if (exist != null)
                {
                    await base.InsertOrUpdate(UpdatedTeacherEntity(exist, entity));
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
        private Teacher UpdatedTeacherEntity(Teacher entityToUpdate, Teacher entity)
        {
            entityToUpdate.TeacherUsername = entity.TeacherUsername;
            entityToUpdate.TeacherPassword = entity.TeacherPassword;
            entityToUpdate.TeacherGivenName = entity.TeacherGivenName;
            entityToUpdate.TeacherSurname = entity.TeacherSurname;
            entityToUpdate.TeacherPhone = entity.TeacherPhone;
            entityToUpdate.TeacherRole = entity.TeacherRole;
            entityToUpdate.SchoolCode = entity.SchoolCode;
            entityToUpdate.TeacherLoginType = entity.TeacherLoginType;
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
