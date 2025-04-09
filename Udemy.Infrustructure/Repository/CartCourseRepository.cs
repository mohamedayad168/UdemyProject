using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository;
public class CartCourseRepository(ApplicationDbContext dbContext)
        : ICartCourseRepository
{
    private readonly ApplicationDbContext dbContext = dbContext;

    public void DeleteCartCourse(CartCourse cartCourse)
    {
        dbContext.CartCourse.Remove(cartCourse);
    }
}
