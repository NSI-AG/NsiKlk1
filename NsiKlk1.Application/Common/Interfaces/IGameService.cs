using NsiKlk1.Application.Common.Dto.Game;

namespace NsiKlk1.Application.Common.Interfaces;

public interface IGameService
{
    Task<GameDetailsDto> CreateAsync(GameCreateDto game, CancellationToken cancellationToken);
}
