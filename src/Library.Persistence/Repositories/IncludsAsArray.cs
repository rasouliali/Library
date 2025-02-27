//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;

//namespace Library.Persistence.Repositories
//{
//    public static class IQueryableExtensions
//    {
//        public static IQueryable<TEntity> GetAllIncluding<TEntity>(this IQueryable<TEntity> queryable, params string[] includeProperties)
//        {
//            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
//        }

//        public static IQueryable<TEntity> GetAllIncludingWithFunc<TEntity>(this IQueryable<TEntity> queryable, params Expression<Func<TEntity, object>>[] includeProperties)
//        {
//            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
//        }
//    }
//}
