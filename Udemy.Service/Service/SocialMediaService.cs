using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class SocialMediaService(IRepositoryManager repositoryManager, IMapper mapper) : ISocialMediaService

    {
        public async Task<List<SocialMediaDto>> GetUserSocialMedias(int userId)
        {
            var socialMedias = await repositoryManager.SocialMedia.GetByUserIdAsync(userId);
            return mapper.Map<List<SocialMediaDto>>(socialMedias);
        }

        public async Task<SocialMediaDto> GetSocialMedia(int id, int userId)
        {
            var socialMedia = await repositoryManager.SocialMedia.GetByIdAsync(id, userId);
            if (socialMedia == null)
                throw new KeyNotFoundException("Social media not found");

            return mapper.Map<SocialMediaDto>(socialMedia);
        }

        public async Task<SocialMediaDto> CreateSocialMedia(int userId, SocialMediaDto dto)
        {
            // Validate platform doesn't already exist for user
            if (await repositoryManager.SocialMedia.ExistsForUser(userId, dto.Name))
                throw new InvalidOperationException($"User already has a {dto.Name} profile");

            var socialMedia = new SocialMedia
            {
                UserId = userId,
                Name = dto.Name,
                Link = dto.Link,
                Id = dto.Id,
            };

            var created = await repositoryManager.SocialMedia.CreateAsync(socialMedia);
            return mapper.Map<SocialMediaDto>(created);
        }

        public async Task<SocialMediaDto> UpdateSocialMedia(int id, int userId, UpdateSocialMediaDto dto)
        {
            var socialMedia = await repositoryManager.SocialMedia.GetByIdAsync(id, userId);
            if (socialMedia == null)
                throw new KeyNotFoundException("Social media not found");

            if (!string.IsNullOrEmpty(dto.Link))
                socialMedia.Link = dto.Link;

            var updated = await repositoryManager.SocialMedia.UpdateAsync(socialMedia);
            return mapper.Map<SocialMediaDto>(updated);
        }

        public async Task DeleteSocialMedia(int id, int userId)
        {
            var socialMedia = await repositoryManager.SocialMedia.GetByIdAsync(id, userId);
            if (socialMedia == null)
                throw new KeyNotFoundException("Social media not found");

            await repositoryManager.SocialMedia.Delete(socialMedia.Id, socialMedia.UserId);
        }

        public Task<SocialMediaDto> UpdateSocialMedia(int id, int userId, SocialMediaDto dto)
        {
            throw new NotImplementedException();
        }


    }
}
