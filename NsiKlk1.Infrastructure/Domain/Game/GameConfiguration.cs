using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NsiKlk1.Domain.Enums;

namespace NsiKlk1.Infrastructure.Domain.Game;

public class GameConfiguration : IEntityTypeConfiguration<NsiKlk1.Domain.Entities.Game>
{
    public void Configure(EntityTypeBuilder<NsiKlk1.Domain.Entities.Game> builder)
    {
        builder.ToTable("Games");

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property<Guid>("DeveloperId");
        
        builder.HasIndex("DeveloperId");
        
        builder.HasOne(b => b.Developer)
               .WithMany(b => b.Games)
               .HasForeignKey("DeveloperId")
               .IsRequired();
        builder.Property(b => b.Category)
            .IsRequired()
            .HasDefaultValue(Category.Singleplayer)
            .HasConversion(p => p.Value,
                p => Category.FromValue(p));
    }
}