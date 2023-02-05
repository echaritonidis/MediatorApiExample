using MediatorApiExample.Responses.OrderResponse;
using MediatR;

namespace MediatorApiExample.Commands.OrderCommand
{
    public class GetOrderCommand : IRequest<OrderResponse>
    {
        public string Id { get; set; }
    }
}

