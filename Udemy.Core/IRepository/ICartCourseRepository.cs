using Udemy.Core.Entities;

namespace Udemy.Core.IRepository;
public interface ICartCourseRepository
{
    void DeleteCartCourse(CartCourse cartCourse);
}
