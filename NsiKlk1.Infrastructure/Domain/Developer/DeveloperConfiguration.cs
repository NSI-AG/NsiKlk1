using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NsiKlk1.Infrastructure.Domain.Developer;

public class DeveloperConfiguration : IEntityTypeConfiguration<NsiKlk1.Domain.Entities.Developer>
{
    public void Configure(EntityTypeBuilder<NsiKlk1.Domain.Entities.Developer> builder)
    {
        builder.ToTable("Developers");

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