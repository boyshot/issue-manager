using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebIssueManagementApp.Interface;

namespace WebIssueManagementApp.Repositories
{
  public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private DbContext context;
    private DbSet<TEntity> dbSet;

    public RepositoryBase(DbContext context)
    {
      this.context = context;
      this.dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
      return await Get(null, null);
    }

    public virtual async Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "", int take = 0)
    {
      IQueryable<TEntity> query = dbSet;

      if (filter != null)
      {
        query = query.Where(filter);
      }

      foreach (var includeProperty in includeProperties.Split
          (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(includeProperty);
      }

      if (take > 0)
      {
        if (orderBy != null)
          return await orderBy(query).Take(take).ToListAsync();

        return await query.Take(take).ToListAsync();
      }

      if (orderBy != null)
        return await orderBy(query).ToListAsync();

      return await query.ToListAsync();
    }

    public virtual async Task<TEntity> GetById(params object[] keyValues)
    {
      return await dbSet.FindAsync(keyValues);
    }

    public virtual void Insert(TEntity entity)
    {
      dbSet.Add(entity);
    }

    public virtual void Delete(params object[] keyValues)
    {
      TEntity entityToDelete = dbSet.Find(keyValues);
      Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
      if (context.Entry(entityToDelete).State == EntityState.Detached)
      {
        dbSet.Attach(entityToDelete);
      }
      dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
      dbSet.Attach(entityToUpdate);
      context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public virtual void Save()
    {
      context.SaveChanges();
    }
  }
}
