using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Infrastructure.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace NsiKlk1.FunctionalTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    public Mock<IDeveloperService> MockDeveloperService { get; } = new();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<NsiKlk1DbContext>();

            var dbName = Guid.NewGuid()
                .ToString();

            services.AddDbContext<NsiKlk1DbContext>(options =>
            {
                options.UseInMemoryDatabase(dbName);
            });
            
            services.AddScoped(_ => MockDeveloperService.Object);
        });
    }
}
