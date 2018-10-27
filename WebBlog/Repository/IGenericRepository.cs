using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebBlog.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        Task Delete(TEntity entity);
        TEntity FindById(Guid Id);
        IList<TEntity> GetAll();
        PagedResult<TEntity> GetListPaged(IQueryable<TEntity> query, int page, int pageSize);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }
}
