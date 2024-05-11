namespace NsiKlk1.Application.Common.Dto.Game;

public record GameDetailsDto(string Name, string Description, string? DeveloperName, string DeveloperDescription, string CategoryName, List<string> Subcategories);