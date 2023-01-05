using MediatorApiExample.Responses.CustomerResponse;
using MediatR;

namespace MediatorApiExample.Commands.CustomerCommand
{
    public class GetAllCustomerCommand : IRequest<CustomersResponse>
    {
    }
}

