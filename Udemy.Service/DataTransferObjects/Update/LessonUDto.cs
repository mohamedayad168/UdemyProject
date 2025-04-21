namespace Udemy.Service.DataTransferObjects.Update
{
    public class LessonUDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public int SectionId { get; set; }
        public bool isDeleted { get; set; }
    }

}
