using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository
{
    public class CategoriesRepository(ApplicationDbContext dbContext) : RepositoryBase<Category>(dbContext), ICategoriesRepository
    {

    }



}
