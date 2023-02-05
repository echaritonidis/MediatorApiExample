using MediatorApiExample.Responses.OrderResponse;
using MediatR;

namespace MediatorApiExample.Commands.OrderCommand
{
    public class GetAllOrderCommand : IRequest<OrdersResponse>
    {
        public string CustomerId { get; set; }
    }
}

