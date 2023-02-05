using MediatorApiExample.Responses.OrderResponse;
using MediatR;
using MediatorApiExample.Dto;

namespace MediatorApiExample.Commands.OrderCommand
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public OrderDto Order { get; set; }
    }
}

