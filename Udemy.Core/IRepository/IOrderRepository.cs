using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges);
        Task<Order> GetOrderAsync(int id, bool trackChanges);
    }
}
