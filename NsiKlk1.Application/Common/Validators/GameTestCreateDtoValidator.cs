using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Application.Games.Commands;
using NsiKlk1.Domain.Common.Extensions;
using NsiKlk1.Domain.Enums;
using FluentValidation;

namespace NsiKlk1.Application.Common.Validators;

public class GameTestCreateDtoValidator : AbstractValidator<GameTestCreateDto>
{
    public GameTestCreateDtoValidator()
    {
        RuleFor(x => x.Json)
            .Must(t => t.TryDeserializeJson<GameCreateCommand>(out _,
                SerializerExtensions.SettingsWebOptions))
            .WithMessage("Json is not in good format");

    }
}
