using MediatorApiExample.Responses.CustomerResponse;
using MediatR;

namespace MediatorApiExample.Commands.CustomerCommand
{
    public class DeleteCustomerCommand : IRequest
    {
        public string Id { get; set; }
    }
}

