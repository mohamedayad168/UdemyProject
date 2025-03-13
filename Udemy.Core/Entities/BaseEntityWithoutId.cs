using Udemy.Core.Interface;

namespace Udemy.Core.Entities;
public class BaseEntityWithoutId: IBaseEntityWithoutId
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
