using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository;
public class CartRepository(ApplicationDbContext dbContext)
        : RepositoryBase<Cart>(dbContext), ICartRepository
{
    private readonly ApplicationDbContext dbContext = dbContext;

    public async Task<IEnumerable<Cart>> GetAllCartsAsync(bool trackChanges , RequestParamter requestParamter)
    {
        return await FindAll(trackChanges)
            .Where(x => x.IsDeleted != true)
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }
    public async Task<Cart?> GetCartByIdAsync(int id , bool trackChanges)
    {
        return await FindByCondition(c => c.Id == id && c.IsDeleted != true , trackChanges)
            .FirstOrDefaultAsync();
    }
    public void CreateCart(Cart cart)
    {
        Create(cart);
    }
    public void DeleteCart(Cart cart)
    {
        cart.IsDeleted = true;
    }
}
