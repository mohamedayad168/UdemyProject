namespace Udemy.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
