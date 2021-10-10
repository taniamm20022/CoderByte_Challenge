using CoderByte_DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoderByte_DAL.Repositories
{
    public class GenericRepository<TContext, TEntity>
        : IGenericRepository<TEntity>
        where TContext : DbContext where TEntity : class
    {
        private readonly TContext DataContext;
        protected DbSet<TEntity> DbSet { get; set; }

        public GenericRepository(
          TContext dbContext)
        {
            DataContext = dbContext;
            DbSet = DataContext.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool asNoTracking = false)
        {
            var query = GetQueryable(predicate, orderBy, include, null, null);
            return await query.ToListAsync();
        }


        protected IQueryable<TEntity> GetQueryable(
          Expression<Func<TEntity, bool>> predicate,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include,
          int? skip,
          int? take)
        {
            IQueryable<TEntity> query = DbSet;
            
            query = query.AsQueryable();

            if (include != null)
            {
                query = include(query);
            }


            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

    }
}
