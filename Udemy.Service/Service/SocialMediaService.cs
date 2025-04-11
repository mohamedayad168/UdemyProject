using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class SocialMediaService(IRepositoryManager repositoryManager, IMapper mapper) : ISocialMediaService

    {
        public Task Create(List<SocialMedia> socialMedia)
        {
            throw new NotImplementedException();
        }


        //public Task<List<SocialMediaDto>> Create(List<SocialMedia> socialMediasDto)
        //{
        //    var socialMedia = mapper.Map<List<SocialMedia>>(socialMediasDto);
        //    var result = repositoryManager.SocialMedia.Create(socialMedia);
        //    if (result != null)
        //    {
        //        return mapper.Map<List<SocialMediaDto>>(result);
        //    }
        //}

        public Task Delete(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<SocialMediaDto> GetSocialMediaById(int id, int userId)
        {
            var socialMedia = await repositoryManager.SocialMedia.GetSocialMediaByIdAsync(id, userId);
            if (socialMedia != null)
            {
                var socialMediaDto = new SocialMediaDto()
                {
                    Link = socialMedia.Link,
                    Name = socialMedia.Name,
                };
                return socialMediaDto;
            }
            throw new Exception("not found");

        }

        public Task<SocialMedia> GetSocialMediaByIdAsync(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SocialMedia>> GetSocialMediaByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task Update(List<SocialMedia> socialMedia)
        {
            throw new NotImplementedException();
        }
    }
}
