namespace NsiKlk1.Application.Common.Dto.Game;

public record GameCreateDto(Guid DeveloperId, string Name, string Description, int Category);