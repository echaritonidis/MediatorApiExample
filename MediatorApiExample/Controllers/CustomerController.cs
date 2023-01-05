using System.Threading.Tasks;
using MediatorApiExample.Commands.CustomerCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatorApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCustomers")]
        public async Task<IActionResult> Get(GetAllCustomerCommand command) 
        {
            var result = await _mediator.Send(command);

            return Ok(result.Customers);
        }

        [HttpGet(Name = "GetCustomer")]
        public async Task<IActionResult> Get(GetCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result.Customer);
        }

        [HttpPost(Name = "CreateCustomer")]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result.Customer);
        }

        [HttpPut(Name = "UpdateCustomer")]
        public IActionResult Update(UpdateCustomerCommand command)
        {
            _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public IActionResult Delete(DeleteCustomerCommand command)
        {
            _mediator.Send(command);

            return NoContent();
        }
    }
}
