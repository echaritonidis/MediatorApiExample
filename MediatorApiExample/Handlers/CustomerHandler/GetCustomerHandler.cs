using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Commands.CustomerCommand;
using MediatorApiExample.Responses.CustomerResponse;
using MediatorApiExample.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace MediatorApiExample.Handlers.CustomerHandler
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<GetCustomerHandler> _logger;

        public GetCustomerHandler(ILogger<GetCustomerHandler> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public Task<CustomerResponse> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerService.Get(ObjectId.Parse(request.Id));

            _logger.LogInformation($"Get customer with id {customer.Id}");

            return Task.FromResult(new CustomerResponse { Customer = customer });
        }
    }
}

