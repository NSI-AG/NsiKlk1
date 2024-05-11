using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace NsiKlk1.FunctionalTests;

public class BaseTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    public readonly HttpClient Client;
    public readonly NsiKlk1DbContext NsiKlk1DbContext;
    public readonly Mock<IDeveloperService> MockDeveloperService;

    public BaseTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = factory.CreateClient();
        var scope = factory.Services.CreateScope();
        NsiKlk1DbContext = scope.ServiceProvider.GetRequiredService<NsiKlk1DbContext>();
        MockDeveloperService = factory.MockDeveloperService;
    }
}
