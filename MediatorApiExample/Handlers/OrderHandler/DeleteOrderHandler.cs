using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Commands.CustomerCommand;
using MediatorApiExample.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace MediatorApiExample.Handlers.OrderHandler
{
    public class DeleteOrderHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<DeleteOrderHandler> _logger;

        public DeleteOrderHandler(ILogger<DeleteOrderHandler> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var order = _orderService.Get(ObjectId.Parse(request.Id));

            _orderService.Remove(order.Id);

            _logger.LogInformation($"Order deleted with id {order.Id}");

            return Task.FromResult<Unit>(default);
        }
    }
}

