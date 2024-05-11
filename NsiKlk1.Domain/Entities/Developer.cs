namespace NsiKlk1.Domain.Entities;

public class Developer
{
    private Developer() {}
    public Developer(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = Name + " developer";
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IList<Game> Games { get; } = new List<Game>();
}