using NsiKlk1.Application.Common.Exceptions;
using NsiKlk1.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NsiKlk1.Application.Developers.Commands
{
    public record DeveloperDeleteCommand(Guid DeveloperId) : IRequest<bool>;

    public class DeveloperDeleteCommandHandler : IRequestHandler<DeveloperDeleteCommand, bool>
    {
        private readonly INsiKlk1DbContext _dbContext;

        public DeveloperDeleteCommandHandler(INsiKlk1DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeveloperDeleteCommand request, CancellationToken cancellationToken)
        {
            var developer = await _dbContext.Developers
                .FirstOrDefaultAsync(p => p.Id == request.DeveloperId, cancellationToken);

            if (developer == null)
                throw new NotFoundException("Developer not found.");

            _dbContext.Developers.Remove(developer);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}