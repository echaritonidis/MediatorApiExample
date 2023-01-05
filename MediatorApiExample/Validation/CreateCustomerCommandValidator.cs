using FluentValidation;
using MediatorApiExample.Commands.CustomerCommand;

namespace MediatorApiExample.Validation
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Customer).NotNull();
        }
    }
}

