using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
    public interface ISocialMediaRepository
    {
        Task<SocialMedia> GetSocialMediaByIdAsync(int id, int userId);
        Task<IEnumerable<SocialMedia>> GetSocialMediaByUserIdAsync(int userId);

    }
}
