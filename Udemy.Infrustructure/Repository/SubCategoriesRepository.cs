using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository
{
    public class SubCategoriesRepository(ApplicationDbContext dbContext) : RepositoryBase<SubCategory>(dbContext), ISubCategoriesRepository
    {
    }



}
