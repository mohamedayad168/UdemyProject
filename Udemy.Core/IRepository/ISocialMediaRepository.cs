using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
    public interface ISocialMediaRepository
    {
        Task<List<SocialMedia>> GetByUserIdAsync(int userId);
        Task<SocialMedia?> GetByIdAsync(int id, int userId);
        Task<SocialMedia> CreateAsync(SocialMedia socialMedia);
        Task<SocialMedia> UpdateAsync(SocialMedia socialMedia);
        Task<bool> ExistsForUser(int userId, string platform);
        Task Delete(int id, int userId);

    }
}
