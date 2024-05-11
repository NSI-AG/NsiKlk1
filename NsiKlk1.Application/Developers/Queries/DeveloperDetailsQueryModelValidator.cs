using FluentValidation;

namespace NsiKlk1.Application.Developers.Queries;

public class DeveloperDetailsQueryModelValidator : AbstractValidator<DeveloperDetailsQuery>
{
    public DeveloperDetailsQueryModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty.")
            .MinimumLength(3);
    }
}