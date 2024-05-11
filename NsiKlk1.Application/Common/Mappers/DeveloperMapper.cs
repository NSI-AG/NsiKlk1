using NsiKlk1.Application.Common.Dto.Developer;
using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace NsiKlk1.Application.Common.Mappers;

[Mapper]
public static partial class DeveloperMapper
{
    public static DeveloperDetailsDto ToDto(this Developer entity)
    {
        var dto = new DeveloperDetailsDto(entity.Name,
            entity.Description);
        return dto;
    }
    public static Developer FromCreateDtoToEntity(this DeveloperCreateDto dto)
    {
        var developer = new Developer(dto.Name,
            dto.Description);
        return developer;
    }
    public static Developer ToCustomDto(this DeveloperCreateDto dto)
    {
        var developer = new Developer(dto.Name, dto.Description);
        
        return developer;
    }

}