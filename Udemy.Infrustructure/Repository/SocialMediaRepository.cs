using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository
{
    public class SocialMediaRepository : RepositoryBase<SocialMedia>, ISocialMediaRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SocialMediaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SocialMedia> GetSocialMediaByIdAsync(int id, int userId)
        {
            return await dbContext.SocialMedias
                .FirstOrDefaultAsync(sm => sm.Id == id && sm.UserId == userId);

        }

        public async Task<IEnumerable<SocialMedia>> GetSocialMediaByUserIdAsync(int userId)
        {
            return await dbContext.SocialMedias
                   .Where(sm => sm.UserId == userId)
                   .ToListAsync();
        }
        public async Task<List<SocialMedia>> Create(List<SocialMedia> socialMedias)
        {
            foreach (var socialMedia in socialMedias)
            {
                await dbContext.Set<SocialMedia>().AddAsync(socialMedia);
                await dbContext.SaveChangesAsync();
            }
            return socialMedias;

        }

        public async Task Update(List<SocialMedia> socialMedias)
        {
            foreach (var socialMedia in socialMedias)
            {
                dbContext.Set<SocialMedia>().Update(socialMedia);
                await dbContext.SaveChangesAsync();
            }

        }
        public async Task Delete(int Id, int userId)
        {
            var socialMedia = await dbContext.SocialMedias
                .FirstOrDefaultAsync(sm => sm.Id == Id && sm.UserId == userId);

            if (socialMedia != null)
            {
                socialMedia.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }

        }


    }
}
