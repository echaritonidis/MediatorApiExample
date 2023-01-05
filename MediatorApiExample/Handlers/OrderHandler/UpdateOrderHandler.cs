using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Commands.OrderCommand;
using MediatorApiExample.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace MediatorApiExample.Handlers.OrderHandler
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<UpdateOrderHandler> _logger;

        public UpdateOrderHandler(ILogger<UpdateOrderHandler> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var id = ObjectId.Parse(request.Id);
            var order = _orderService.Get(id);

            order.ProductName = request.OrderIn.ProductName;
            order.OrderPlaced = request.OrderIn.OrderPlaced;
            order.Quantity = request.OrderIn.Quantity;
            order.Amount = request.OrderIn.Amount;

            _orderService.Update(id, order);

            _logger.LogInformation($"Order with id {order.Id} updated");

            return Task.FromResult<Unit>(default);
        }
    }
}

