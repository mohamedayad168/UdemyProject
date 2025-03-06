using System.Linq.Expressions;

namespace Udemy.Core.IRepository;

//public interface IGenericRepository<T> where T : class
//{
//    // CRUD Operations
//    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
//    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
//    Task AddAsync(T entity, CancellationToken cancellationToken = default);
//    Task AddMultipleAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
//    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
//    Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
//    Task RemoveAsync(T entity, CancellationToken cancellationToken = default);
//    Task RemoveMultipleAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

//    //// Query Operations
//    //Task<IEnumerable<T>> FindAsync(
//    //    Expression<Func<T, bool>> predicate,
//    //    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
//    //    CancellationToken cancellationToken = default);
//    //public IQueryable<T> Find(
//    //    Expression<Func<T, bool>> predicate,
//    //    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);


//    //Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
//    //Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

//    //// Pagination and Sorting
//    //Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
//    //    Expression<Func<T, bool>> predicate,
//    //    int pageNumber,
//    //    int pageSize,
//    //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
//    //    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
//    //    CancellationToken cancellationToken = default);

//    //// Specification Pattern
//    //Task<IEnumerable<T>> FindBySpecificationAsync(
//    //    ISpecification<T> specification,
//    //    CancellationToken cancellationToken = default);
//}

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T , bool>> expression , bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}