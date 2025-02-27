using Library.Application.Interface.Persistence;
using Library.Domain.Entities.Base;
using Library.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private LibraryContext _context;
        public GenericRepository(LibraryContext db)
        {
            this._context = db;
        }
        public async Task<int> AddAsync(TEntity model)
        {
            _context.Set<TEntity>().Add(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }


        public async Task<bool> UpdateAsync(TEntity objModel,bool fromDeleted = false)
        {
            var entry = _context.Entry(objModel);
            _context.Entry(objModel).State = EntityState.Modified;
            entry.Property("CreatedUserId").IsModified = false;
            entry.Property("CreatedDate").IsModified = false;
            if(fromDeleted==false)
                entry.Property("IsDeleted").IsModified = false;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await GetAsync(id);
            if (data != null)
            {
                data.IsDeleted = true;
                var res = await UpdateAsync(data,true);
                return res;
            }
            return false;
        }
        public async Task<List<TEntity>> GetAllAsync(string[] includeProperties = null)
        {
            if(includeProperties == null)
                return _context.Set<TEntity>().Where(r => r.IsDeleted == false).OrderByDescending(r => r.Id).ToList();

            var entityData = _context.Set<TEntity>().Include(includeProperties[0]);
            for (var index=1;index<includeProperties.Length;index++)
            {
                entityData = entityData.Include(includeProperties[index]);
            }
            return entityData.Where(r => r.IsDeleted == false).OrderByDescending(r => r.Id).ToList();
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(r => r.IsDeleted == false).Where<TEntity>(predicate).OrderByDescending(r=>r.Id).ToList();
        }

    }

    //public static class IQueryableExtensions
    //{
    //    public static IQueryable<TEntity> GetAllIncluding<TEntity>(this IQueryable<TEntity> queryable, params string[] includeProperties)
    //    {
    //        return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
    //    }

    //    public static IQueryable<TEntity> GetAllIncludingWithFunc<TEntity>(this IQueryable<TEntity> queryable, params Expression<Func<TEntity, object>>[] includeProperties)
    //    {
    //        return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
    //    }
    //}
}
