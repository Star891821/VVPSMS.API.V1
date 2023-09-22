using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers
{
    public class GenericService<T> : ICommonService<T> where T : class
    {
        protected VvpsmsdbContext context;
        internal DbSet<T> dbSet;

        public GenericService(VvpsmsdbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<List<T>> GetAll(int id)
        {
            return await dbSet.Where(e => e.Equals(id)).ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> InsertOrUpdateRange(List<T> entity)
        {
            if (!dbSet.Local.Any(e => e == entity))
            {
                await dbSet.AddRangeAsync(entity);
                return true;
            }
            return false;
        }
        public virtual async Task<bool> InsertOrUpdate(T entity)
        {
            if (!dbSet.Local.Any(e => e == entity))
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            return false;
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<bool> Remove(T entity)
        {
            if (dbSet.Local.Any(e => e == entity))
            {
                dbSet.Remove(entity);
                return true;
            }
            return false;
        }

        public virtual async Task<bool> RemoveRange(List<T> entity)
        {
            if (dbSet.Local.Any(e => e == entity))
            {
                dbSet.RemoveRange(entity);
                return true;
            }
           return false;
           
        }
    }
}
