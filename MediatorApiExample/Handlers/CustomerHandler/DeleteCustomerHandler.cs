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
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<DeleteCustomerHandler> _logger;

        public DeleteCustomerHandler(ILogger<DeleteCustomerHandler> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerService.Get(ObjectId.Parse(request.Id));

            _customerService.Remove(customer.Id);

            _logger.LogInformation($"Customer deleted with id {customer.Id}");

            return Task.FromResult<Unit>(default);
        }
    }
}

