using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.BaseTests.Builders.Commands;
using NsiKlk1.BaseTests.Builders.Domain;
using NsiKlk1.BaseTests.Builders.Dto;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;

namespace NsiKlk1.FunctionalTests.Games.Commands;

public class GameCreateCommandTests : BaseTests
{
    [Fact]
    public async Task GameCreateCommandTest_GivenValidGame_StatusOk()
    {
        //Given
        var developer = new DeveloperBuilder().Build();

        await NsiKlk1DbContext.Developers.AddAsync(developer);
        await NsiKlk1DbContext.SaveChangesAsync();

        var gameDto = new GameCreateDtoBuilder().WithDeveloperId(developer.Id)
            .Build();

        var game = new GameCreateCommandBuilder().WithGameCreateDto(gameDto)
            .Build();

        var jsonGame = JsonSerializer.Serialize(game);
        var contentRequest = new StringContent(jsonGame,
            Encoding.UTF8,
            "application/json");

        MockDeveloperService.Setup(x => x.CreateAsync())
            .Returns("Test");

        //When
        var response = await Client.PostAsync("/api/Game/Create/create",
            contentRequest,
            new CancellationToken());

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<GameDetailsDto>();

        content.Should()
            .NotBeNull();

        MockDeveloperService.Verify(x => x.CreateAsync(), Times.Once);
    }

    public GameCreateCommandTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}
