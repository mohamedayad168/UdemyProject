namespace Udemy.Service.DataTransferObjects.Read
{
    public class RatingRDTO
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public DateTime date { get; set; }

        public decimal Rating { get; set; }
        public string Comment { get; set; } = string.Empty;

    }
}