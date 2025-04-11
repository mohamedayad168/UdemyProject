using Udemy.Core.Entities;

namespace Udemy.Service.IService
{
    public interface ISocialMediaService
    {
        Task<SocialMedia> GetSocialMediaByIdAsync(int id, int userId);
        Task Create(List<SocialMedia> socialMedia);
        Task<IEnumerable<SocialMedia>> GetSocialMediaByUserIdAsync(int userId);
        Task Update(List<SocialMedia> socialMedia);
        Task Delete(int id, int userId);
    }
}
