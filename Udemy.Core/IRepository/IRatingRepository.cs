using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
    public interface IRatingRepository : IRepositoryBase<Rating>
    {
        Task AddOrUpdateRatingAsync(int studentId, int courseId, decimal rating, string? comment);
    }
}
