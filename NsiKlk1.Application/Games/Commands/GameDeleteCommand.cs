using NsiKlk1.Application.Common.Exceptions;
using NsiKlk1.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NsiKlk1.Application.Games.Commands
{
    public record GameDeleteCommand(Guid GameId) : IRequest<bool>;

    public class GameDeleteCommandHandler : IRequestHandler<GameDeleteCommand, bool>
    {
        private readonly INsiKlk1DbContext _dbContext;

        public GameDeleteCommandHandler(INsiKlk1DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(GameDeleteCommand request, CancellationToken cancellationToken)
        {
            var game = await _dbContext.Games
                .FirstOrDefaultAsync(p => p.Id == request.GameId, cancellationToken);

            if (game == null)
                throw new NotFoundException("Game not found.");

            _dbContext.Games.Remove(game);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}