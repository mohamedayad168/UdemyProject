using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.Core.Entities;
using Udemy.Core.Extensions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository;
public class CartRepository(ApplicationDbContext dbContext)
        : RepositoryBase<Cart>(dbContext), ICartRepository
{
    private readonly ApplicationDbContext dbContext = dbContext;

    public async Task<IEnumerable<Cart>> GetAllCartsAsync(
        bool trackChanges , RequestParamter requestParamter ,
        params Func<IQueryable<Cart> , IQueryable<Cart>>[] includes
    )
    {
        return await FindAll(trackChanges)
            .IncludeRelated(includes)
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }


    public async Task<Cart?> GetStudentCartByIdAsync(
        int studentId , bool trackChanges ,
        params Func<IQueryable<Cart> , IQueryable<Cart>>[] includes
    )
    {
        return await FindByCondition(c => c.StudentId == studentId , trackChanges)
            .IncludeRelated(includes)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> CheckIfStudentCartExist(int studentId)
    {
        return await dbContext.Carts.AnyAsync(x => x.StudentId == studentId);
    }

    public void CreateCart(Cart cart)
    {
        Create(cart);
    }


    public void DeleteCart(Cart cart)
    {
        Delete(cart);
    }

    public void DeleteCartCourse(CartCourse cartCourse)
    {
        dbContext.CartCourse.Remove(cartCourse);
    }
}
