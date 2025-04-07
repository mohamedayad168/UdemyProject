namespace Udemy.Service.DataTransferObjects.Read
{
    public class CourseRatingRDTO
    {
        public int CourseId { get; set; }
        public decimal Rating { get; set; }
        public int TotalReviews { get; set; }
        public int InstructorId { get; set; }
        public IEnumerable<RatingRDTO> Ratings { get; set; }
    }
}