using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Commands.OrderCommand;
using MediatorApiExample.Responses.OrderResponse;
using MediatorApiExample.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatorApiExample.Handlers.OrderHandler
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderCommand, OrdersResponse>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<GetAllOrderHandler> _logger;

        public GetAllOrderHandler(ILogger<GetAllOrderHandler> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public Task<OrdersResponse> Handle(GetAllOrderCommand request, CancellationToken cancellationToken)
        {
            var orders = _orderService.GetOrdersForCustomer(request.CustomerId);

            return Task.FromResult(new OrdersResponse { Orders = orders });
        }
    }
}

