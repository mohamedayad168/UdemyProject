using Udemy.Core.IRepository;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class SocialMediaService : ISocialMediaService

    {
        private readonly IRepositoryManager repositoryManager;
        public SocialMediaService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }
        //public async Task<SocialMediaDto> GetSocialMediaById(int id, int userId)
        //{
        //    var socialMedia = await repositoryManager.SocialMedia.GetSocialMediaByIdAsync(id, userId);
        //    if (socialMedia != null)
        //    {
        //        var socialMediaDto = new SocialMediaDto()
        //        {
        //            Link = socialMedia.Link,
        //            Name = socialMedia.Name,
        //        };
        //        return socialMediaDto;
        //    }

        //}
    }
}
