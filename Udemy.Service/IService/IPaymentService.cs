using Udemy.Service.DataTransferObjects.Read;

namespace Udemy.Service.IService;
public interface IPaymentService
{
    Task<CartDto> CreateOrUpdatePaymentIntent(int cartId);
}
