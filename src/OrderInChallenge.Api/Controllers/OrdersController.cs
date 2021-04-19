using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderInChallenge.Commands.Order.Create;

namespace OrderInChallenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISender sender;

        public OrdersController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand createOrderCommand)
        {
            await this.sender.Send(createOrderCommand);
            return Ok();
        }
    }
}
