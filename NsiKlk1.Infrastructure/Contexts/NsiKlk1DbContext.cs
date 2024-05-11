using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Domain.Entities;

namespace NsiKlk1.Infrastructure.Contexts;

public class NsiKlk1DbContext(DbContextOptions<NsiKlk1DbContext> options) : IdentityDbContext<
    ApplicationUser, 
    ApplicationRole, 
    string, 
    IdentityUserClaim<string>, 
    ApplicationUserRole, 
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>
    >(options), INsiKlk1DbContext
{
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Developer> Developers => Set<Developer>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}