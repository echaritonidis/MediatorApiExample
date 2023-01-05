using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Commands.CustomerCommand;
using MediatorApiExample.Responses.CustomerResponse;
using MediatorApiExample.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatorApiExample.Handlers.CustomerHandler
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CreateCustomerHandler> _logger;

        public CreateCustomerHandler(ILogger<CreateCustomerHandler> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerService.Create(new Models.Customer(request.Customer.FirstName, request.Customer.LastName, request.Customer.Birthday));

            _logger.LogInformation($"Created customer with id {customer.Id}");

            return Task.FromResult(new CustomerResponse { Customer = customer });
        }
    }
}

