using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public RatingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        public async Task AddOrUpdateRatingAsync(int studentId, int courseId, decimal rating, string comment)
        {
            var enrollment = _context.Enrollments
                .FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrollment != null)
            {
                enrollment.Rating = rating;
                enrollment.comment = comment;
                _context.Enrollments.Update(enrollment);
            }
            else
            {
                var newEnrollment = new Enrollment
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    Rating = rating,
                    comment = comment,
                    StartDate = DateTime.UtcNow,
                    Status = "Enrolled"
                };
                _context.Enrollments.Add(newEnrollment);
            }

            await _context.SaveChangesAsync();
        }
    }
}

