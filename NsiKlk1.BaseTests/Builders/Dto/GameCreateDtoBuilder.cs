using NsiKlk1.Application.Common.Dto.Game;

namespace NsiKlk1.BaseTests.Builders.Dto;

public class GameCreateDtoBuilder
{
    private Guid _developerId;
    private string _name = "-";
    private string _description = "-";
    private int _category = 1;

    public GameCreateDtoBuilder WithDeveloperId(Guid developerId)
    {
        _developerId = developerId;
        return this;
    }

    public GameCreateDtoBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public GameCreateDtoBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public GameCreateDtoBuilder WithCategory(int category)
    {
        _category = category;
        return this;
    }

    public GameCreateDto Build() => new(_developerId, _name, _description, _category);
}