using System.ComponentModel;
using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Domain.Entities;
using NsiKlk1.Domain.Enums;
using Riok.Mapperly.Abstractions;

namespace NsiKlk1.Application.Common.Mappers;

[Mapper]
public static partial class GameMapper
{
    public static GameDetailsDto ToDto(this Game entity)
    {
        var dto = new GameDetailsDto(entity.Name,
            entity.Description,
            entity.Developer.Name,
            entity.Developer.Description,
            entity.Category.Name,
            entity.Category
                .Subcategories
                .Select(x => x.Name)
                .ToList());
        return dto;
    }
    public static Game FromCreateDtoToEntity(this GameCreateDto dto)
    {
        var game = new Game(dto.Name,
            dto.Description,
            Category.FromValue(dto.Category));
        return game;
    }
    public static Game ToCustomDto(this GameCreateDto dto, Developer developer, Category category)
    {
        var game = new Game(
            dto.Name, 
            dto.Description,
            category);
        
        return game;
    }

}