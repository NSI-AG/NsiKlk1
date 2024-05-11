using NsiKlk1.Application.Common.Dto.Developer;
using NsiKlk1.Application.Common.Exceptions;
using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Application.Common.Mappers;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.EntityFrameworkCore;
using NsiKlk1.Application.Common.Dto.Developer;

namespace NsiKlk1.Application.Developers.Commands;

public record DeveloperCreateCommand(DeveloperCreateDto Developer) : IRequest<DeveloperDetailsDto?>;

public class DeveloperCreateCommandHandler(INsiKlk1DbContext dbContext) : IRequestHandler<DeveloperCreateCommand, DeveloperDetailsDto?>
{
    public async Task<DeveloperDetailsDto?> Handle(DeveloperCreateCommand request, CancellationToken cancellationToken)
    {
        var developer = request.Developer
            .FromCreateDtoToEntity();
        
        dbContext.Developers.Add(developer);
        await dbContext.SaveChangesAsync(cancellationToken);

        return developer.ToDto();
    }
}