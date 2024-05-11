using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Application.Common.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NsiKlk1.Application.Common.Dto.Developer;
using NsiKlk1.Application.Games.Queries;

namespace NsiKlk1.Application.Developers.Queries;

public record DeveloperDetailsQuery(string Id) : IRequest<DeveloperDetailsDto?>;

public class DeveloperDetailsQueryHandler(INsiKlk1DbContext dbContext) : IRequestHandler<DeveloperDetailsQuery, DeveloperDetailsDto?>
{
    public async Task<DeveloperDetailsDto?> Handle(DeveloperDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext.Developers
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return result?.ToDto();
    }
}