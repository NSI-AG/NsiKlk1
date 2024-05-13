using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Application.Common.Exceptions;
using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Application.Common.Mappers;
using NsiKlk1.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace NsiKlk1.Infrastructure.Services;

public class GameService(INsiKlk1DbContext dbContext, IDeveloperService developerService) : IGameService
{
    public async Task<GameDetailsDto> CreateAsync(GameCreateDto game, CancellationToken cancellationToken)
    {
        var test = developerService.CreateAsync();
        var developer = await dbContext.Developers
            .Where(x => x.Id == game.DeveloperId)
            .FirstOrDefaultAsync(cancellationToken);

        if (developer == null)
            throw new NotFoundException("Developer not exist!");

        var gameEntity = game.FromCreateDtoToEntity()
            .AddDeveloper(developer);

        dbContext.Games.Add(gameEntity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return gameEntity.ToDto();
    }
}
