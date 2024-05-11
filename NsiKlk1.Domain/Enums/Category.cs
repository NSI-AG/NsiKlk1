using Ardalis.SmartEnum;

namespace NsiKlk1.Domain.Enums;

public abstract class Category : SmartEnum<Category>
{
    public static Category Singleplayer = new SingleplayerCategory();
    public static Category RPG = new RPGCategory();
    public static Category Simulation = new SimulationCategory();
    public static Category Multiplayer = new MultiplayerCategory();
    public static Category Sports = new SportsCategory();
    public static Category FPS = new FPSCategory();

    public abstract string Description { get; }
    public abstract List<Category> Subcategories { get; }

    public Category(string name, int value) : base(name,
        value)
    {
    }

    private sealed class SingleplayerCategory : Category
    {
        public SingleplayerCategory() : base(nameof(Singleplayer),
            1)
        {
        }

        public override string Description => "Opis o singleplayer igrama!";

        public override List<Category> Subcategories => new()
        {
            RPG, Simulation
        };
    }

    private sealed class MultiplayerCategory : Category
    {
        public MultiplayerCategory() : base(nameof(Multiplayer),
            2)
        {
        }

        public override string Description => "Opis o multiplayer igrama!";

        public override List<Category> Subcategories => new()
        {
            Sports, FPS
        };
    }

    private sealed class RPGCategory : Category
    {
        public RPGCategory() : base(nameof(RPG),
            3)
        {
        }

        public override string Description => "Opis o RPG igrama!";

        public override List<Category> Subcategories => new();
    }

    private sealed class SimulationCategory : Category
    {
        public SimulationCategory() : base(nameof(Simulation),
            4)
        {
        }

        public override string Description => "Opis o simulacijama!";

        public override List<Category> Subcategories => new();
    }
    
    private sealed class SportsCategory : Category
    {
        public SportsCategory() : base(nameof(Sports),
            5)
        {
        }

        public override string Description => "Opis o sportskim igrama!";

        public override List<Category> Subcategories => new();
    }
    
    private sealed class FPSCategory : Category
    {
        public FPSCategory() : base(nameof(FPS),
            6)
        {
        }

        public override string Description => "Opis o FPS igrama!";

        public override List<Category> Subcategories => new();
    }
}
