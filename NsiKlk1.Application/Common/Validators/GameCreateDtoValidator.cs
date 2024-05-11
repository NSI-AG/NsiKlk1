using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Domain.Common.Extensions;
using NsiKlk1.Domain.Enums;
using FluentValidation;

namespace NsiKlk1.Application.Common.Validators;

public class GameCreateDtoValidator : AbstractValidator<GameCreateDto>
{
    public GameCreateDtoValidator()
    {
        RuleFor(x => x.DeveloperId)
            .NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Description)
            .MaximumLength(350);
        
        RuleFor(x => x.Category)
            .Must(t => Category.TryFromValue(t, out _))
            .WithMessage(_ => $"Category is not valid, category must be in list of: {EnumExtensions.CategoryValidList}");

    }
}
