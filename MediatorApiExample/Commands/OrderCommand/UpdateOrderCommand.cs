using MediatorApiExample.Dto;
using MediatR;

namespace MediatorApiExample.Commands.OrderCommand
{
    public class UpdateOrderCommand : IRequest
    {
        public OrderDto OrderIn { get; set; }

        public string Id { get; set; }
    }
}

