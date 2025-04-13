using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService
{
    public interface ICoursesService
    {
        //read
        public Task<IEnumerable<CourseRDTO>> GetAllAsync(bool trackChanges);
        Task<IEnumerable<CourseRDTO>> GetAllByCategoryId(int categoryId);
        public Task<IEnumerable<CourseRDTO>> GetPageAsync(RequestParamter requestParamter, bool trackChanges);
        public Task<CourseRDTO?> GetByTitleAsync(string title, bool trackChanges);
        public Task<CourseRDTO> GetByIdAsync(int id, bool trackChanges);

        public Task<CourseDetailsRDto> GetCourseDetailsAsync(int id, bool trackChanges);
        Task<IEnumerable<CourseRDTO>> GetAllBySubcategoryId(int subcategoryId);
        Task<IEnumerable<CourseSearchDto>> GetAllWithSearchAsync(CourseRequestParameter requestParamter);

        //write
        public Task<CourseRDTO> CreateAsync(CourseCDTO course);
        public Task<CourseRDTO> UpdateAsync(CourseUDTO course);
        public Task<bool> ToggleApprovedAsync(int id);

        //
        public Task DeleteAsync(int id);

    }


    public class CourseDetailsRDto
    {
        public CourseDetailsRDto(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Description = course.Description;
            Status = course.Status;
            CourseLevel = course.CourseLevel;
            Discount = course.Discount;
            Price = course.Price;
            Duration = course.Duration;
            Language = course.Language;
            ImageUrl = course.ImageUrl;
            VideoUrl = course.VideoUrl;
            NoSubscribers = course.NoSubscribers;
            IsFree = course.IsFree;
            BestSeller = course.BestSeller;
            CurrentPrice = course.CurrentPrice;
            Rating = course.Rating;
            SubCategory = new SubCategoryRDTO(course.SubCategory);

            Instructor = new InstructorRDTO()
            {
                Id = course.Instructor.Id,
                UserName = course.Instructor.FirstName + " " + course.Instructor.LastName,
                Title = course.Instructor.Title,
                Bio = course.Instructor.Bio
            };
            CourseGoals = course.CourseGoals.Select(x => x.Goal).ToList();
            CourseRequirements = course.CourseRequirements.Select(x => x.Requirement).ToList();
            Sections = course.Sections.Select(x => new SectionDto(x)).ToList();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CourseLevel { get; set; }
        public decimal? Discount { get; set; }
        public decimal Price { get; set; }
        public decimal Duration { get; set; }
        public string Language { get; set; }
        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public int NoSubscribers { get; set; }
        public bool IsFree { get; set; }
        public string? BestSeller { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal? Rating { get; set; }

        public SubCategoryRDTO SubCategory { get; set; }

        public InstructorRDTO Instructor { get; set; }

        public List<string> CourseGoals { get; set; }
        public List<string> CourseRequirements { get; set; }
        public List<SectionDto> Sections { get; set; }
    }

    public class SectionDto
    {
        public SectionDto(Section section)
        {
            Id = section.Id;
            Title = section.Title;
            Duration = section.Duration;
            NoLessons = section.Lessons.Count;
            Lessons = section.Lessons.Select(x => new LessonDto(x)).ToList();

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Duration { get; set; }
        public int NoLessons { get; set; }
        public List<LessonDto> Lessons { get; set; }
    }

    public class LessonDto
    {
        public LessonDto(Lesson lesson)
        {
            Id = lesson.Id;
            Title = lesson.Title;
            Duration = lesson.Duration;
            Type = lesson.Type;
            VideoUrl = lesson.VideoUrl;
            ArticleContent = lesson.ArticleContent;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Duration { get; set; }
        public string Type { get; set; }
        public string? VideoUrl { get; set; }
        public string? ArticleContent { get; set; }
    }




}
