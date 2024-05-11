using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Application.Games.Commands;
using NsiKlk1.BaseTests.Builders.Dto;

namespace NsiKlk1.BaseTests.Builders.Commands;

public class GameCreateCommandBuilder
{
    private GameCreateDto _gameCreateDto = new GameCreateDtoBuilder().Build();
    
    public GameCreateCommand Build() => new(_gameCreateDto);
    
    public GameCreateCommandBuilder WithGameCreateDto(GameCreateDto gameCreateDto)
    {
        _gameCreateDto = gameCreateDto;
        return this;
    }

}
