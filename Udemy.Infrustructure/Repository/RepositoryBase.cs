using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.Core.Enums;
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

    public IQueryable<T> FindAll(bool trackChanges = false, DeletionType? deletionType = null)
    {
        IQueryable<T> query;

        if (deletionType is null)
        {
            //if deletion type not specified
            query = dbContext.Set<T>().Where(x => x.IsDeleted == false);
        }
        else
        {
            //if deletion type not specified
            switch (deletionType)
            {
                case DeletionType.Deleted | DeletionType.Deleted:
                    query = dbContext.Set<T>().Where(x => x.IsDeleted == (deletionType == DeletionType.Deleted));
                    break;
                default:
                    query = dbContext.Set<T>();
                    break;
            }
        }

        return trackChanges ? query : query.AsNoTracking();

    }

    public int Count()
    {
        return dbContext.Set<T>().Count();
    }
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
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



