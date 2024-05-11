using Microsoft.EntityFrameworkCore;
using NsiKlk1.Domain.Entities;

namespace NsiKlk1.Application.Common.Interfaces;

public interface INsiKlk1DbContext
{
    public DbSet<Game> Games { get; }
    public DbSet<Developer> Developers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}