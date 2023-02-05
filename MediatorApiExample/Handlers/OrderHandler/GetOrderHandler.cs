using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Commands.OrderCommand;
using MediatorApiExample.Responses.OrderResponse;
using MediatorApiExample.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace MediatorApiExample.Handlers.OrderHandler
{
    public class GetOrderHandler : IRequestHandler<GetOrderCommand, OrderResponse>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<GetOrderHandler> _logger;

        public GetOrderHandler(ILogger<GetOrderHandler> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public Task<OrderResponse> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderService.Get(ObjectId.Parse(request.Id));

            _logger.LogInformation($"Get order with id {order.Id}");

            return Task.FromResult(new OrderResponse { Order = order });
        }
    }
}

