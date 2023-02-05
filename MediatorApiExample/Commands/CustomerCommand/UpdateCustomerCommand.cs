using MediatorApiExample.Dto;
using MediatorApiExample.Responses.CustomerResponse;
using MediatR;

namespace MediatorApiExample.Commands.CustomerCommand
{
    public class UpdateCustomerCommand : IRequest
    {
        public CustomerDto CustomerIn { get; set; }

        public string Id { get; set; }
    }
}

