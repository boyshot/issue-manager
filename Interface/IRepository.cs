using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebIssueManagementApp.Interface
{
  public interface IRepository<TEntity> where TEntity : class
  {
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "", int take = 0);
    Task<TEntity> GetById(params object[] keyValues);

    void Insert(TEntity entity);
    void Delete(params object[] keyValues);
    void Delete(TEntity entityToDelete);
    void Update(TEntity entity);
    void Save();
  }
}
