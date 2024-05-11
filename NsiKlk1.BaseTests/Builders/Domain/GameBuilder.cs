using NsiKlk1.Domain.Entities;
using NsiKlk1.Domain.Enums;

namespace NsiKlk1.BaseTests.Builders.Domain;

public class GameBuilder
{
    private string _name = "-";
    private string _description = "-";
    private Category _category = Category.Singleplayer;
    
    public Game Build() => new(_name,
        _description, _category);

    public GameBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public GameBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }
    
    public GameBuilder WithCategory(Category category)
    {
        _category = category;
        return this;
    }
}
