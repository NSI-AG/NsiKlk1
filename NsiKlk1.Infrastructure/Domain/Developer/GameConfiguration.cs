using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NsiKlk1.Infrastructure.Domain.Developer;

public class GameConfiguration : IEntityTypeConfiguration<NsiKlk1.Domain.Entities.Game>
{
    public void Configure(EntityTypeBuilder<NsiKlk1.Domain.Entities.Game> builder)
    {
        builder.ToTable("Games");

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        /*builder.Property<Guid>("DeveloperId");
        
        builder.HasIndex("DeveloperId");
        
        builder.HasOne(b => b.Developer)
               .WithMany(b => b.Games)
               .HasForeignKey("DeveloperId")
               .IsRequired();*/
    }
}