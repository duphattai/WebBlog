using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebBlog.Entities.Context;

namespace WebBlog.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected BlogEntities _entities;
        protected DbSet<TEntity> _dbSet => _entities.Set<TEntity>();

        public GenericRepository(BlogEntities entities)
        {
            _entities = entities;
        }
        public virtual async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _entities.SaveChanges();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _entities.SaveChanges();

            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _entities.Update(entity);
            _entities.SaveChanges();

            return entity;
        }

        public PagedResult<TEntity> GetListPaged(IQueryable<TEntity> query, int page, int pageSize)
        {
            var result = new PagedResult<TEntity>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).AsNoTracking().ToList();

            return result;
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity FindById(Guid Id)
        {
            return _dbSet.Find(Id);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }
    }
}
