using Udemy.Service.DataTransferObjects;

namespace Udemy.Service.IService
{
    public interface ISocialMediaService
    {
        Task<List<SocialMediaDto>> GetUserSocialMedias(int userId);
        Task<SocialMediaDto> GetSocialMedia(int id, int userId);
        Task<SocialMediaDto> CreateSocialMedia(int userId, SocialMediaDto dto);
        Task<SocialMediaDto> UpdateSocialMedia(int id, int userId, SocialMediaDto dto);
        Task DeleteSocialMedia(int id, int userId);
    }
}
