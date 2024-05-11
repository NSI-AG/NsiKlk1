using FluentValidation;

namespace NsiKlk1.Application.Games.Queries;

public class GameDetailsQueryModelValidator : AbstractValidator<GameDetailsQuery>
{
    public GameDetailsQueryModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty.")
            .MinimumLength(3);
    }
}