using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Application.Common.Exceptions;
using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Application.Common.Mappers;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.EntityFrameworkCore;

namespace NsiKlk1.Application.Games.Commands;

public record GameCreateCommand(GameCreateDto Game) : IRequest<GameDetailsDto?>;

public class GameCreateCommandHandler(INsiKlk1DbContext dbContext) : IRequestHandler<GameCreateCommand, GameDetailsDto?>
{
    public async Task<GameDetailsDto?> Handle(GameCreateCommand request, CancellationToken cancellationToken)
    {
        var developer = await dbContext.Developers
            .Where(x => x.Id == request.Game.DeveloperId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (developer == null)
            throw new NotFoundException("Developer does not exist.");

        var game = request.Game
            .FromCreateDtoToEntity()
            .AddDeveloper(developer);
        
        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync(cancellationToken);

        return game.ToDto();
    }
}