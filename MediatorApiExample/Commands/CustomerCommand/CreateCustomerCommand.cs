using MediatorApiExample.Dto;
using MediatorApiExample.Responses.CustomerResponse;
using MediatR;

namespace MediatorApiExample.Commands.CustomerCommand
{
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public CustomerDto Customer { get; set; }
    }
}

