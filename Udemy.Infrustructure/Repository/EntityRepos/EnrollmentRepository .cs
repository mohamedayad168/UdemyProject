using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;


namespace Udemy.Infrastructure.Repository
{
    public class EnrollmentRepository(ApplicationDbContext context)
        : RepositoryBase<Enrollment>(context), IEnrollmentRepository
    {
        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId , bool trackChanges)
        {
            //return await FindByCondition(e => e.StudentId == studentId, trackChanges)
            //    .Include(e => e.Course)
            //    .ToListAsync();
            return await context.Enrollments.Where(e => e.StudentId == studentId)
                .Include(x => x.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId , bool trackChanges)
        {

            //return await FindByCondition(e => e.CourseId == courseId, trackChanges)
            //    .Include(e => e.Student)
            //    .ToListAsync();

            return await context.Enrollments.Where(e => e.CourseId == courseId)
                        .Include(x => x.Student)
                        .ToListAsync();
        }

        public async Task<Enrollment?> GetEnrollmentAsync(int studentId , int courseId , bool trackChanges)
        {
            return await FindByCondition(e => e.StudentId == studentId && e.CourseId == courseId , trackChanges)
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync();
        }

        public void EnrollCourseToStudent(int studentId , int courseId)
        {
            Create(new Enrollment() { StudentId = studentId , CourseId = courseId , Status = "" });
        }
    }
}
