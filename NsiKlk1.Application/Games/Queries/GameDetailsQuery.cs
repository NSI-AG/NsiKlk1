using Ardalis.GuardClauses;
using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Application.Common.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotFoundException = NsiKlk1.Application.Common.Exceptions.NotFoundException;

namespace NsiKlk1.Application.Games.Queries;

public record GameDetailsQuery(string Id) : IRequest<GameDetailsDto?>;

public class GameDetailsQueryHandler(INsiKlk1DbContext dbContext) : IRequestHandler<GameDetailsQuery, GameDetailsDto?>
{
    public async Task<GameDetailsDto?> Handle(GameDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext.Games
            .Include(x => x.Developer)
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (result == null)
        {
            throw new NotFoundException("Game not found.");
        }

        return result?.ToDto();
    }
}