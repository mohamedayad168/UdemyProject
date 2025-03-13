using System.Linq.Expressions;
using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface ICartRepository
{
    Task<bool> CheckIfStudentCartExist(int studentId);
    void CreateCart(Cart cart);
    void DeleteCart(Cart cart);
    void DeleteCartCourse(CartCourse cartCourse);
    Task<IEnumerable<Cart>> GetAllCartsAsync(bool trackChanges , RequestParamter requestParamter , params Func<IQueryable<Cart> , IQueryable<Cart>>[] includes);
    Task<Cart?> GetStudentCartByIdAsync(int studentId, bool trackChanges , params Func<IQueryable<Cart> , IQueryable<Cart>>[] includes);
}
