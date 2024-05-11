using FluentValidation;

namespace NsiKlk1.Application.Auth.Commands.BeginLoginCommand;

public class BeginLoginModelValidator : AbstractValidator<BeginLoginCommand>
{
    public BeginLoginModelValidator()
    {
        RuleFor(x => x.EmailAddress)
            .EmailAddress()
            .NotEmpty();
    }
}
