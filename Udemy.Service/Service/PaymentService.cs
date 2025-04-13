using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class PaymentService(
    IConfiguration config , 
    IRepositoryManager repositoryManager ,
    IMapper mapper) : IPaymentService
{
    public async Task<CartDto> CreateOrUpdatePaymentIntent(int cartId)
    {
        StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];

        var cart = await repositoryManager.Cart.GetStudentCartByIdAsync(
            cartId, true,
            x => x.Include(a => a.Student) ,
            x => x.Include(a => a.CartCourses).ThenInclude(a => a.Course)
        );

        if(cart is null)
        {
            throw new BadRequestException("Problem With your cart");
        }

        var service = new PaymentIntentService();
        PaymentIntent? intent = null;

        if (string.IsNullOrEmpty(cart.PaymentIntentId))
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = cart.Amount * 100 ?? 0,
                Currency = "usd" ,
                PaymentMethodTypes = ["card"]
            };

            intent = await service.CreateAsync(options);
            cart.PaymentIntentId = intent.Id;
            cart.ClientSecret = intent.ClientSecret;
        }
        else
        {
            var options = new PaymentIntentUpdateOptions()
            {
                Amount = cart.Amount * 100 ?? 0
            };

            intent = await service.UpdateAsync(cart.PaymentIntentId , options);
        }

        await repositoryManager.SaveAsync();

        return mapper.Map<CartDto>(cart);
    }
}
