using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {

        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
