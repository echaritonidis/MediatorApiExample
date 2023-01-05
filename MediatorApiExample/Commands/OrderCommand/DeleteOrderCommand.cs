using MediatR;

namespace MediatorApiExample.Commands.OrderCommand
{
    public class DeleteOrderCommand : IRequest
    {
        public string Id { get; set; }
    }
}

