using System.Threading.Tasks;
using MediatorApiExample.Commands.OrderCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatorApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetOrders")]
        public async Task<IActionResult> Get(GetAllOrderCommand command) 
        {
            var result = await _mediator.Send(command);

            return Ok(result.Orders);
        }

        [HttpGet(Name = "GetOrder")]
        public async Task<IActionResult> Get(GetOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result.Order);
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result.Order);
        }

        [HttpPut(Name = "UpdateOrder")]
        public IActionResult Update(UpdateOrderCommand command)
        {
            _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete(Name = "DeleteOrder")]
        public IActionResult Delete(DeleteOrderCommand command)
        {
            _mediator.Send(command);

            return NoContent();
        }
    }
}

