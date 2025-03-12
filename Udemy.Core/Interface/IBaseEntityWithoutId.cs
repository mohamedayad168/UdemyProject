
namespace Udemy.Core.Interface;
public interface IBaseEntityWithoutId
{
    DateTime CreatedDate { get; set; }
    DateTime? ModifiedDate { get; set; }
    bool IsDeleted { get; set; }
}
