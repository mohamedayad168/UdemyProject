namespace Udemy.Service.DataTransferObjects.Read
{
    public class StudentCourseRDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CourseProgress { get; set; } = string.Empty;

        public decimal? ProgressPercentage { get; set; } = 0; //Added new property

    }


}