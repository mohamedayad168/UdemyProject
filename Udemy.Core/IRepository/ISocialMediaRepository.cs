using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
    public interface ISocialMediaRepository
    {
        Task<SocialMedia> GetSocialMediaByIdAsync(int id, int userId);
        Task<IEnumerable<SocialMedia>> GetSocialMediaByUserIdAsync(int userId);
        Task<List<SocialMedia>> Create(List<SocialMedia> socialMedia);
        Task Update(List<SocialMedia> socialMedia);
        Task Delete(int id, int userId);

    }
}
