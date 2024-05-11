using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Domain.Entities;
using NsiKlk1.Infrastructure.Auth.Extensions;
using NsiKlk1.Infrastructure.Configuration;
using NsiKlk1.Infrastructure.Contexts;
using NsiKlk1.Infrastructure.Identity;
using NsiKlk1.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NsiKlk1.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
        {
            services.AddDbContext<NsiKlk1DbContext>(options =>
                options.UseNpgsql(dbConfiguration.ConnectionString,
                    x => x.MigrationsAssembly(typeof(NsiKlk1DbContext).Assembly.FullName)));
        }
        
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddRoleManager<RoleManager<ApplicationRole>>()
            .AddUserManager<ApplicationUserManager>()
            .AddEntityFrameworkStores<NsiKlk1DbContext>()
            .AddDefaultTokenProviders()
            .AddPasswordlessLoginTokenProvider();
        
        services.AddScoped<INsiKlk1DbContext>(provider => provider.GetRequiredService<NsiKlk1DbContext>());
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IDeveloperService, DeveloperService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
        
        return services;
    }
}