using MediatorApiExample.Responses.CustomerResponse;
using MediatR;

namespace MediatorApiExample.Commands.CustomerCommand
{
    public class GetCustomerCommand : IRequest<CustomerResponse>
    {
        public string Id { get; set; }
    }
}

