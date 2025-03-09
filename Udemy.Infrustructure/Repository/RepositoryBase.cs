using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository;
public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private ApplicationDbContext dbContext;

    public RepositoryBase(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges 
            ? dbContext.Set<T>().AsNoTracking() 
            : dbContext.Set<T>();
       
    }
    public IQueryable<T> FindByCondition(Expression<Func<T , bool>> expression , bool trackChanges)
    {
        return !trackChanges
            ? dbContext.Set<T>().Where(expression).AsNoTracking()
            : dbContext.Set<T>().Where(expression);
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
        dbContext.Set<T>().Remove(entity);
    }
}
