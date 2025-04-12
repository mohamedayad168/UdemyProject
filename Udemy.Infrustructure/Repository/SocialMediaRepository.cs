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

        public async Task<List<SocialMedia>> GetByUserIdAsync(int userId)
        {
            return await dbContext.SocialMedias
                .Where(sm => sm.UserId == userId)
                .OrderBy(sm => sm.Name)
                .ToListAsync();
        }

        public async Task<SocialMedia?> GetByIdAsync(int id, int userId)
        {
            return await dbContext.SocialMedias
                .FirstOrDefaultAsync(sm => sm.Id == id && sm.UserId == userId);
        }

        public async Task<SocialMedia> CreateAsync(SocialMedia socialMedia)
        {
            await dbContext.SocialMedias.AddAsync(socialMedia);
            await dbContext.SaveChangesAsync();
            return socialMedia;
        }

        public async Task<SocialMedia> UpdateAsync(SocialMedia socialMedia)
        {

            dbContext.SocialMedias.Update(socialMedia);
            await dbContext.SaveChangesAsync();
            return socialMedia;
        }
        public async Task<bool> ExistsForUser(int userId, string platform)
        {
            return await dbContext.SocialMedias
                .AnyAsync(sm => sm.UserId == userId && sm.Name == platform);
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
