using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsController(IServiceManager serviceManager): ControllerBase
{
    [HttpPost("{cartId}")]
    [Authorize]
    public async Task<IActionResult> CreateOrUpdatePaymentIntent(int cartId)
    {
        var cartDto = await serviceManager.PaymentService.CreateOrUpdatePaymentIntent(cartId);

        return Ok(cartDto);
    }
}
