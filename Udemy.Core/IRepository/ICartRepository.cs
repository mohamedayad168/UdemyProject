using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface ICartRepository
{
    void CreateCart(Cart cart);
    void DeleteCart(Cart cart);
    Task<IEnumerable<Cart?>> GetAllCartsAsync(bool trackChanges , RequestParamter requestParamter);
    Task<Cart?> GetCartByIdAsync(int id , bool trackChanges);
}
