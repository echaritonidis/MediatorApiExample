using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Commands.CustomerCommand;
using MediatorApiExample.Responses.CustomerResponse;
using MediatorApiExample.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatorApiExample.Handlers.CustomerHandler
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerCommand, CustomersResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<GetAllCustomerHandler> _logger;

        public GetAllCustomerHandler(ILogger<GetAllCustomerHandler> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public Task<CustomersResponse> Handle(GetAllCustomerCommand request, CancellationToken cancellationToken)
        {
            var customers = _customerService.GetAll();

            return Task.FromResult(new CustomersResponse { Customers = customers });
        }
    }
}

