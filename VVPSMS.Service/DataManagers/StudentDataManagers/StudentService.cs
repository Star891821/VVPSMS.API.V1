using Microsoft.EntityFrameworkCore;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Students;

namespace VVPSMS.Service.DataManagers.StudentDataManagers
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        public StudentService(VvpsmsdbContext context) : base(context)
        {
        }
        public override async Task<bool> InsertOrUpdate(Student entity)
        {
            try
            {
                var exist = await dbSet.Where(x => x.StudentId == entity.StudentId)
                                       .FirstOrDefaultAsync();

                if (exist != null)
                {
                    await base.InsertOrUpdate(UpdatedStudentEntity(exist, entity));
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
        private Student UpdatedStudentEntity(Student entityToUpdate, Student entity)
        {
            entityToUpdate.StudentUsername = entity.StudentUsername;
            entityToUpdate.StudentPassword = entity.StudentPassword;
            entityToUpdate.StudentGivenName = entity.StudentGivenName;
            entityToUpdate.StudentSurname = entity.StudentSurname;
            entityToUpdate.StudentPhone = entity.StudentPhone;
            entityToUpdate.StudentRole = entity.StudentRole;
            entityToUpdate.StudentLoginType = entity.StudentLoginType;
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
