using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.Core.Interface;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository;
public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IBaseEntityWithoutId
{
    private ApplicationDbContext dbContext;

    public RepositoryBase(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges
            ? dbContext.Set<T>().Where(x => x.IsDeleted == false).AsNoTracking()
            : dbContext.Set<T>().Where(x => x.IsDeleted == false);

    }

    public int Count()
    {
        return dbContext.Set<T>().Count();
    }
    public IQueryable<T> FindByCondition(Expression<Func<T , bool>> expression , bool trackChanges)
    {
        return !trackChanges
            ? dbContext.Set<T>().Where(expression).Where(x => x.IsDeleted == false).AsNoTracking()
            : dbContext.Set<T>().Where(expression).Where(x => x.IsDeleted == false);
    }
    public void Create(T entity)
    {
        dbContext.Set<T>().Add(entity);

    }
    public void Update(T entity)
    {
        dbContext.Set<T>().Update(entity);

    }
    public void Delete(T entity)
    {
        //dbContext.Set<T>().Remove(entity);
        entity.IsDeleted = true;
    }
}
