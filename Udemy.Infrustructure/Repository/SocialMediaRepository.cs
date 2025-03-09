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
        public async Task Create(SocialMedia socialMedia)
        {
            await dbContext.Set<SocialMedia>().AddAsync(socialMedia);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(SocialMedia socialMedia)
        {
            dbContext.Set<SocialMedia>().Update(socialMedia);
            await dbContext.SaveChangesAsync();
        }
        public async Task Delete(int Id, int userId)
        {
            var socialMedia = await dbContext.SocialMedias
                .FirstOrDefaultAsync(sm => sm.Id == Id && sm.UserId == userId);

            if (socialMedia != null)
            {
                dbContext.SocialMedias.Remove(socialMedia);
                await dbContext.SaveChangesAsync();
            }

        }


    }
}
