namespace Udemy.Core.Entities
{
    public class Section : BaseEntity
    {
        public string SectionTitle { get; set; }

        public int SectionOrder { get; set; } //newly Added

        public int Duration { get; set; }
        public int NumberOfLessons { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
        public List<Lesson> Lessons { get; set; } = new();
    }
}
