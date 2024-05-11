using System.Net;
using System.Net.Http.Json;
using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.BaseTests.Builders.Domain;
using NsiKlk1.Domain.Entities;
using NsiKlk1.Domain.Enums;
using FluentAssertions;
using FluentAssertions.Execution;

namespace NsiKlk1.FunctionalTests.Games.Queries;

public class GameDetailsQueryTests : BaseTests
{
    [Fact]
    public async Task GameDetailsQueryTest_GivenValidGameId_StatusOk()
    {
        //Given
        var developer = new DeveloperBuilder().Build();
        var game = new GameBuilder()
            .WithDescription("bilo koji description")
            .Build()
            .AddDeveloper(developer);

        await NsiKlk1DbContext.Games.AddAsync(game);
        await NsiKlk1DbContext.SaveChangesAsync();

        //When
        var response = await Client.GetAsync($"/api/Game/Details?Id={game.Id.ToString()}");

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<GameDetailsDto>();

        content.Should()
            .NotBeNull();

        content!.Name
            .Should()
            .Be(game.Name);

        content.DeveloperName
            .Should()
            .Be(developer.Name);
    }

    [Fact]
    public async Task GameDetailsQueryTest_GivenGameIdAsNull_BadRequest()
    {
        //Given

        //When
        var response = await Client.GetAsync("/api/Game/Details");

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GameDetailsQueryTest_GivenNotExistingGameId_NotFound()
    {
        //Given
        var developer = new Developer("-",
            "-");
        var game = new Game("-",
            "-", Category.Singleplayer).AddDeveloper(developer);

        await NsiKlk1DbContext.Games.AddAsync(game);
        await NsiKlk1DbContext.SaveChangesAsync();

        //When
        var response = await Client.GetAsync($"/api/Game/Details?Id={Guid.NewGuid()}");

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    public GameDetailsQueryTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}
