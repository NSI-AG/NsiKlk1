using Ardalis.GuardClauses;
using NsiKlk1.Domain.Enums;

namespace NsiKlk1.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Developer Developer { get; private set; }
    public Category Category { get; private set; }
    
    private Game() {}

    public Game(string name, string description, Category category)
    {
        Id = Guid.NewGuid();
        Name = Guard.Against.NullOrEmpty(name);
        Description = Guard.Against.StringTooShort(description, 1);
        Category = Guard.Against.Null(category);
    }

    public Game AddDeveloper(Developer developer)
    {
        Developer = developer;
        Description = Name + " by " + Developer.Name;
        return this;
    }
}