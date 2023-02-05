using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Commands.OrderCommand;
using MediatorApiExample.Responses.OrderResponse;
using MediatorApiExample.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatorApiExample.Handlers.OrderHandler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<CreateOrderHandler> _logger;

        public CreateOrderHandler(ILogger<CreateOrderHandler> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderCommand = request.Order;

            var orderModel = new Models.Order(orderCommand.CustomerId, orderCommand.ProductName, orderCommand.OrderPlaced, orderCommand.Quantity, orderCommand.Amount);
            
            var createdOrder = _orderService.Create(orderModel);

            _logger.LogInformation($"Created order with id {createdOrder.Id} for customer {createdOrder.CustomerId}");

            return Task.FromResult(new OrderResponse { Order = createdOrder });
        }
    }
}

