using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Commands.CustomerCommand;
using MediatorApiExample.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace MediatorApiExample.Handlers.CustomerHandler
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<UpdateCustomerHandler> _logger;

        public UpdateCustomerHandler(ILogger<UpdateCustomerHandler> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var id = ObjectId.Parse(request.Id);
            var customer = _customerService.Get(id);

            customer.FirstName = request.CustomerIn.FirstName;
            customer.LastName = request.CustomerIn.LastName;
            customer.Birthday = request.CustomerIn.Birthday;

            _customerService.Update(id, customer);

            _logger.LogInformation($"Customer with id {customer.Id} updated");

            return Task.FromResult<Unit>(default);
        }
    }
}

